using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingBullet : MonoBehaviour
{

    Transform Target;
    public float BulletSpeed;
    private PlayerMove PM;

    // Start is called before the first frame update
    void Start()
    {
        PM = GetComponent<PlayerMove>();
        Target = GameObject.FindGameObjectWithTag("Player").transform;
        Destroy(this.gameObject, 4);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Target.position, BulletSpeed * Time.deltaTime);
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
