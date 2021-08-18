using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Collider2D _playerCollider2d;
    [SerializeField] private Jump _jump;
    private void Update()
    {
        ExitAttack();
    }
    public void DoAttack()
    {
        if(_jump._anim.GetBool("Attack") == false)
        {
            _playerCollider2d.enabled = true;
            _jump._anim.SetBool("Attack", true);
        }
    }
    public void ExitAttack()
    {
        if (_jump._anim.GetCurrentAnimatorStateInfo(0).IsName("attack") == true && _jump._anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            _jump._anim.SetBool("Attack", false);
            _playerCollider2d.enabled = false;
        }
    }
    
}
