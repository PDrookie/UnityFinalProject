using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShoot : MonoBehaviour
{

    GameObject Target;
    public float disappearTime;
    public float BulletSpeed;
    Rigidbody2D bulletRB;
    private PlayerAttributes PA;

    // Start is called before the first frame update
    void Start()
    {
        PA = GameObject.Find("Player").GetComponent<PlayerAttributes>();
        bulletRB = GetComponent<Rigidbody2D>();
        Target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (Target.transform.position - transform.position).normalized * BulletSpeed;
        if (bulletRB != null)
        {
            bulletRB.velocity = new Vector2(moveDir.x, moveDir.y + 0.5f);
        }
        Destroy(this.gameObject, disappearTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag.Equals("Player"))
        {
            if (PA._Invicible)
            {
                PA._Invicible = false;
            }
            else
            {
                PA.HP -= 1;
            }
            Destroy(this.gameObject, 0.1f);
            
        }
    }
}
