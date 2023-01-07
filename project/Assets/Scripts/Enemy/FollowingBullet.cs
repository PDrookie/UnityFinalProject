using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingBullet : MonoBehaviour
{

    Transform Target;
    public float BulletSpeed;
    private PlayerAttributes PA;

    // Start is called before the first frame update
    void Start()
    {
        PA = GameObject.Find("Player").GetComponent<PlayerAttributes>();
        Target = GameObject.FindGameObjectWithTag("Player").transform;
        Destroy(this.gameObject, 3);
    }

    private void Update()
    {
        Vector2 targerPos = new Vector2(Target.position.x, Target.position.y + 0.8f);
        transform.position = Vector2.MoveTowards(this.transform.position, targerPos, BulletSpeed * Time.deltaTime);
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
