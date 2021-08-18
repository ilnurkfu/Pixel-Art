using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    public enum STATE
    {
        IDLE, ATTACK
    };
    public enum EVENT
    {
        ENTER, UPDATE, EXIT
    };

    public STATE name;
    protected EVENT _stage;
    protected GameObject _npc;
    protected Animator _anim;
    protected Transform _player;
    protected State _nextState;

    private float _attackDistance = 0.643f;
    public State(GameObject npc, Animator anim, Transform player)
    {
        _npc = npc;
        _anim = anim;
        _player = player;
    }
    public virtual void Enter() { _stage = EVENT.UPDATE; }
    public virtual void Update() { _stage = EVENT.UPDATE; }
    public virtual void Exit() { _stage = EVENT.EXIT; }
    public State Process()
    {
        if (_stage == EVENT.ENTER) Enter();
        if (_stage == EVENT.UPDATE) Update();
        if (_stage == EVENT.EXIT)
        {
            Exit();
            return _nextState;
        }
        return this;
    }
    public bool CanAttackPlayer()
    {
        Vector2 directory = _npc.transform.position - _player.transform.position;
        if(directory.x <= _attackDistance)
        {
            return true;
        }
        return false;
    }
}
public class Idle : State
{
    public Idle(GameObject npc, Animator anim, Transform player) : base(npc, anim, player)
    {
        name = STATE.IDLE;
    }
    public override void Enter()
    {
        base.Enter();
    }
    public override void Update()
    {
        if(CanAttackPlayer())
        {
            _nextState = new NpcAttack(_npc, _anim, _player);
            _stage = EVENT.EXIT;
        }
        base.Update();
    }
    public override void Exit()
    {
        base.Exit();
    }
}
public class NpcAttack : State
{
    public NpcAttack(GameObject npc, Animator anim, Transform player) : base(npc, anim, player)
    {
        name = STATE.ATTACK;
    }
    public override void Enter()
    {
        base.Enter();
    }
    public override void Update()
    {

        if (!CanAttackPlayer())
        {
            _nextState = new Idle(_npc, _anim, _player);
            _stage = EVENT.EXIT;
        }
        base.Update();
    }
    public override void Exit()
    {
        base.Exit();
    }
}


