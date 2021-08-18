using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private bool _isWalk;
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _player;
    [SerializeField] private Animator _anim;
    void FixedUpdate()
    {
        if (_isWalk)
        {
           
            _anim.SetBool("Run", true);
        }
        else
        {
            _anim.SetBool("Run", false);
        }
    }
    public void Walk()
    {
        _isWalk = true;
    }
    public void UnWalk()
    {
        _isWalk = false;
    }
}
