using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRedFish : OceanEnemy
{
    public float Speed;
    public float startWaitTime;
    public float AttackRange;
    public float shootingRange;
    public float fireRate = 4.5f;
    private float NextFireTime;
    private float waitTime;

    public Transform movePos;
    public Transform LeftDownPos;
    public Transform RightUpPos;
    private Transform player;

    public GameObject[] bullet;
    public GameObject bulletParent;

    private bool PlayerCome = false;
    private bool movingRight = true;

    // Start is called before the first frame update
    public void Start()
    {
        base.Start();

        waitTime = startWaitTime;
        movePos.position = GetRandomPos();

        player = PlayerMove.instance;
    }

    // Update is called once per frame
    public void Update()
    {
        base.Update();

        float ChangePosition = Vector2.Distance(transform.position, movePos.position);
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);

        if (distanceFromPlayer < AttackRange && distanceFromPlayer > shootingRange)
        {
            PlayerCome = true;
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, Speed * Time.deltaTime);
        }
        else if (distanceFromPlayer <= shootingRange && NextFireTime < Time.time)
        {
            int mode = Random.Range(0, 2);
            Instantiate(bullet[mode], bulletParent.transform.position, Quaternion.identity);
            NextFireTime = Time.time + fireRate;
        }
        else
        {
            PlayerCome = false;
        }
        if (!PlayerCome)
        {
            transform.position = Vector2.MoveTowards(transform.position, movePos.position, Speed * Time.deltaTime);

            if (ChangePosition < 0.1f)
            {
                if (waitTime <= 0)
                {
                    movePos.position = GetRandomPos();
                    flipTheBody();
                    waitTime = startWaitTime;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
        }
        if(PlayerCome) flipTowardPlayer();
    }

    void flipTowardPlayer()
    {
        float playerDirection = player.position.x - transform.position.x;

        if (playerDirection > 0 && !movingRight)
        {
            flip();
        }
        else if (playerDirection < 0 && movingRight)
        {
            flip();
        }
    }

    void flip()
    {
        movingRight = !movingRight;
        //Debug.Log("Rotate");
        transform.Rotate(0, -180, 0);
    }

    Vector2 GetRandomPos()
    {
        Vector2 rndPos = new Vector2(Random.Range(RightUpPos.position.x, LeftDownPos.position.x), Random.Range(RightUpPos.position.y, LeftDownPos.position.y));
        return rndPos;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AttackRange);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }

    void flipTheBody()
    {
        float fishDirection = movePos.position.x - transform.position.x;
        //Debug.Log(fishDirection);

        if (fishDirection > 0 && !movingRight)
        {
            flip();
        }
        else if (fishDirection < 0 && movingRight)
        {
            flip();
        }
    }
}
