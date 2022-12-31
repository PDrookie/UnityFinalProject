using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHited : MonoBehaviour
{
    [SerializeField]private float HitForce;
    [SerializeField] private float HitTime;
    private Rigidbody2D playerRB;
    private PlayerMove PM;
    private float countTime;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = transform.GetComponent<Rigidbody2D>();
        PM = transform.GetComponent<PlayerMove>();
        countTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (PM.IsHited)
        {
            countTime += Time.deltaTime;
        }
        if (countTime >= HitTime)
        {
            PM.IsHited = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag.Equals("Enemy"))
        {
            Debug.Log("?");
            countTime = 0;
            playerRB.velocity = Vector2.zero;
            PM.IsHited = true;
            playerRB.AddForce(new Vector2(HitForce * (transform.position.x - collision.transform.position.x), HitForce * (transform.position.y - collision.transform.position.y)));
        }
    }
}
