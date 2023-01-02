using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlyEye : CaveEnemy
{
    public float Speed;
    public float startWaitTime;
    public float AttackRange;
    public float shootingRange;
    public float fireRate = 2.5f;
    private float NextFireTime;
    private float waitTime;

    public Transform movePos;
    public Transform LeftDownPos;
    public Transform RightUpPos;
    private Transform player;

    public GameObject bullet;
    public GameObject bulletParent;
    
    private bool PlayerCome = false;
    private bool movingLeft = true;

    // Start is called before the first frame update
    public void Start()
    {
        base.Start();
        Health = 100;
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
            Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
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
        if (PlayerCome) flipTowardPlayer();

    }

    void flipTowardPlayer()
    {
        float playerDirection = player.position.x - transform.position.x;

        if(playerDirection > 0 && movingLeft)
        {
            flip();
        }
        else if(playerDirection < 0 && !movingLeft)
        {
            flip();
        }
    }

    void flip()
    {
        movingLeft = !movingLeft;
        transform.Rotate(0, 180, 0);
    }

    void flipTheBody()
    {
        float flyeyeDirection = movePos.position.x - transform.position.x;
        //Debug.Log(flyeyeDirection);

        if (flyeyeDirection > 0 && movingLeft)
        {
            flip();
        }
        else if (flyeyeDirection < 0 && !movingLeft)
        {
            flip();
        }
    }

    Vector2 GetRandomPos()
    {
        Vector2 rndPos = new Vector2(Random.Range(RightUpPos.position.x, LeftDownPos.position.x), Random.Range(RightUpPos.position.y, LeftDownPos.position.y));
        return rndPos;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, AttackRange);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
}
