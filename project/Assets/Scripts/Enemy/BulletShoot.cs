using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShoot : MonoBehaviour
{

    GameObject Target;
    public float disappearTime;
    public float BulletSpeed;
    Rigidbody2D bulletRB;
    private PlayerMove PM;

    // Start is called before the first frame update
    void Start()
    {
        PM = GetComponent<PlayerMove>();
        bulletRB = GetComponent<Rigidbody2D>();
        Target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (Target.transform.position - transform.position).normalized * BulletSpeed;
        bulletRB.velocity = new Vector2(moveDir.x, moveDir.y + 0.5f);
        Destroy(this.gameObject, disappearTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag.Equals("Player"))
        {
            Debug.Log("Hitttt");            
            Destroy(this.gameObject, 0.1f);
            //PM.IsHited = true;
            //乾這邊有鬼 佳豪哥你加油
        }
    }
}
