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
            Debug.Log("Hitttt");
            Destroy(this.gameObject, 0.1f);
            //PM.IsHited = true;
            //乾這邊有鬼 佳豪哥你加油
        }
    }
}
