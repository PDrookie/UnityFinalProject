using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private int CoinPlayerGet = 0;
    private PlayerAttributes PA;
    private void Start()
    {
        PA = GameObject.Find("Player").GetComponent<PlayerAttributes>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            CoinPlayerGet++;
            PA.Coins += 100;
            Destroy(gameObject);
        }
    }
}
