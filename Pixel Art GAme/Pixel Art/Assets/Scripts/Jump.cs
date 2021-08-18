
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public bool _isGrounded;
    [SerializeField] private Transform _jumpPoint;
    [SerializeField] private  float _jumpHeihgt;
    [SerializeField] private  float _jumpRange;
    [SerializeField] private const float _gravity = -9.8f;
    public Rigidbody2D _rb2d;
    public Animator _anim;

    private void FixedUpdate()
    { 
        if(_rb2d.velocity.y > 0.5f)
        {
            _anim.SetBool("JumpStart", true);
            _isGrounded = false;
            //Debug.Log("Jump");

        }
        else if (_rb2d.velocity.y < -0.5f)
        {
            _anim.SetBool("JumpEnd", true);
            _isGrounded = false;
            //Debug.Log("fall");
        }
        if(_rb2d.position.x >= _jumpPoint.position.x)
        {
            _rb2d.velocity = Vector2.up * Physics2D.gravity / 16;
            _jumpPoint.position += Vector3.right * 0.643f;
        }
    }
   
    public void DoJump()
    {
        if (_isGrounded == true)
        {
            //_rb2d.AddForce(transform.up * Mathf.Sqrt(-2 * _jumpHeihgt * _gravity) + transform.right * ((transform.position.x - _jumpPoint.position.x) / (Mathf.Sqrt(-2 * _jumpHeihgt / _gravity) + Mathf.Sqrt(2 * (transform.position.y - _jumpPoint.position.y - _jumpHeihgt)) / _gravity)), ForceMode2D.Impulse);
            //Debug.Log(transform.up * Mathf.Sqrt(-2 * _jumpHeihgt * _gravity));
            //Debug.Log(transform.right * ((_rb2d.position.x - _jumpPoint.position.x) / (Mathf.Sqrt(-2 * _jumpHeihgt / _gravity) + Mathf.Sqrt(2 * (_jumpPoint.position.y - _rb2d.position.y - _jumpHeihgt) / _gravity))));
            //Debug.Log(transform.up * Mathf.Sqrt(-2 * _jumpHeihgt * _gravity) + transform.right * ((_rb2d.position.x - _jumpPoint.position.x) / (Mathf.Sqrt(-2 * _jumpHeihgt / _gravity) + Mathf.Sqrt(2 * (_rb2d.position.y - _jumpPoint.position.y - _jumpHeihgt) / _gravity))));
            //_rb2d.AddForce(transform.up * Mathf.Sqrt(-2 * _jumpHeihgt * _gravity));
            //_rb2d.AddForce(transform.up * Mathf.Sqrt(-2 * _jumpHeihgt * _gravity) + transform.right * ((_jumpPoint.position.x - _rb2d.position.x) / (Mathf.Sqrt(-2 * _jumpHeihgt / _gravity) + Mathf.Sqrt(2 * (- _jumpPoint.position.y - _rb2d.position.y - _jumpHeihgt) / _gravity))));
            //Debug.Log(_rb2d.transform.localPosition.x);
            //Debug.Log(_rb2d.transform.localPosition.y);
            //_rb2d.velocity = Vector2.up * Mathf.Sqrt(-2 * _jumpHeihgt * _gravity) + Vector2.right * ((_jumpPoint.position.x - _rb2d.position.x) / (Mathf.Sqrt(-2 * _jumpHeihgt / _gravity) + Mathf.Sqrt(2 * (-_jumpPoint.position.y - _rb2d.position.y - _jumpHeihgt) / _gravity)));
            //_rg2d.velocity = Vector2.right * _speed;
            //_rg2d.velocity = Vector2.right * _speed;
            //_rg2d.AddForce(Vector2.up * _jumpHeihgt);
            //_rg2d.AddForce(Vector2.right * _speed)
            _rb2d.AddForce(Vector2.up * _jumpHeihgt + Vector2.right * _jumpRange, ForceMode2D.Impulse);

        }

    }

  
}