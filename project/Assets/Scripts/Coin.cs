using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private int CoinPlayerGet = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            CoinPlayerGet++;
            Debug.Log(CoinPlayerGet);   
            //佳豪哥這邊金幣增加
            Destroy(gameObject);
        }
    }
}
