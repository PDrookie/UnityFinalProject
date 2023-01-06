using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPortal : MonoBehaviour
{
    public GameObject portal;
    public bool InsidePortal;
    private GameObject Player;
    public int AllowThroughTimes;
    private int Calculate;
    private Boss B;

    // Start is called before the first frame update
    void Start()
    {
        B = GameObject.Find("BossSpawner").GetComponent<Boss>();
        Calculate = AllowThroughTimes;
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "weapon")
        {
            Calculate --;
            //Debug.Log(Calculate);
            if (Calculate == 0)
            {
                Player.transform.position = new Vector2(portal.transform.position.x, portal.transform.position.y);
                Calculate = AllowThroughTimes;
                if (InsidePortal)
                {
                    transform.gameObject.SetActive(false);
                    B.bossTriger = true;
                }
            }
            
        }
    }

}
