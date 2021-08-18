using UnityEngine;

public class Player : MonoBehaviour
{   
    [SerializeField] private Jump _jump;
    [SerializeField] private Attack _attack;
    [SerializeField] private Characteristics _characteristics;
    [SerializeField] private CoinControl _coin;
    [SerializeField] private float _timer;
    [SerializeField] private float _cooldown;

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>() && _jump._anim.GetBool("Attack") == true)
        {
            Characteristics newP = collision.gameObject.GetComponent<Characteristics>();
            newP.TakeDamage();
            newP.Death();
            _attack._playerCollider2d.enabled = false;
        }
        if(collision.gameObject.GetComponent<Coin>() && _jump._anim.GetBool("Attack") == false)
        {
            _coin.AddCoin(collision);
            _coin.DisplayCoin();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Grid>())
        {
            //Debug.Log("Grounded");
            _jump._isGrounded = true;
            _jump._anim.SetBool("JumpEnd", false);
            _jump._anim.SetBool("JumpStart", false);
            _jump._rb2d.velocity = Vector2.zero;
        }
    }
}
