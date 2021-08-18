using UnityEngine;

public class Characteristics : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private GameObject _heart1, _heart2, _heart3;
    private void Start()
    {
        DisplayHealth();
    }
    public void DisplayHealth()
    {
        switch (_health)
        {
            case 3:
                _heart1.SetActive(true);
                _heart2.SetActive(true);
                _heart3.SetActive(true);
                break;

            case 2:
                _heart1.SetActive(true);
                _heart2.SetActive(true);
                _heart3.SetActive(false);
                break;

            case 1:
                _heart1.SetActive(true);
                _heart2.SetActive(false);
                _heart3.SetActive(false);
                break;

            case 0:
                _heart1.SetActive(false);
                _heart2.SetActive(false);
                _heart3.SetActive(false);
                break;
        }
        
    }
    public void TakeDamage()
    {
        _health -= 1;
        DisplayHealth();
        
    }
    public void TakeHeal()
    {
        _health += 1;
        DisplayHealth();
    }
    public void Death()
    {
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
