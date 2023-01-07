using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHited : MonoBehaviour
{
    [SerializeField]private float HitForce;
    [SerializeField] private float HitTime;
    [SerializeField] private GameObject DialogBox;
    [SerializeField] private GameObject DialogBox2;
    private PlayerAttributes PA;
    private Rigidbody2D playerRB;
    private PlayerMove PM;
    private float countTime;


    // Start is called before the first frame update
    void Start()
    {
        playerRB = transform.GetComponent<Rigidbody2D>();
        PM = transform.GetComponent<PlayerMove>();
        PA = transform.GetComponent<PlayerAttributes>();
        countTime = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PM.IsHited)
        {
            countTime += Time.deltaTime;
        }
        if (countTime >= HitTime)
        {
            //countTime = 0;
            //Debug.Log(countTime + " " + HitTime);
            PM.IsHited = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag.Equals("Enemy"))
        {
            countTime = 0;
            playerRB.velocity = Vector2.zero;
            PM.IsHited = true;
            playerRB.AddForce(new Vector2(HitForce * (transform.position.x - collision.transform.position.x), HitForce * (transform.position.y - collision.transform.position.y)));
            if (PA._Invicible)
            {
                PA._Invicible = false;
            }
            else
            {
                PA.HP -= 1;
            }
 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag.Equals("mystery"))
        {
            DialogBox.SetActive(true);
        }
        if (collision.transform.tag.Equals("warrior"))
        {
            DialogBox2.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag.Equals("mystery"))
        {
            DialogBox.SetActive(false);
        }
        if (collision.transform.tag.Equals("warrior"))
        {
            DialogBox2.SetActive(false);
        }
    }
}
