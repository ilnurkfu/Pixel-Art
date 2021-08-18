using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinControl : MonoBehaviour
{
    [SerializeField] private int _coin;
    [SerializeField] private Text _text;
    public void AddCoin(Collider2D collision)
    {
        _coin += 1;
        Destroy(collision.gameObject);
    }
    public void DisplayCoin()
    {
        _text.text = $"Монет: {_coin}";
    }


}
