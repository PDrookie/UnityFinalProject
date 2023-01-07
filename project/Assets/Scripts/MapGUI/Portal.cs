using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject portal;
    private GameObject Player;
    public float arrivePos;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (transform.name.Equals("ShopDestination") && collision.transform.position.x>transform.position.x)
            {
                return;
            }
            Player.transform.position = new Vector2(portal.transform.position.x + arrivePos, portal.transform.position.y);
        }
    }
}
