using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlueFish : OceanEnemy
{
    public float Speed;
    public float startWaitTime;
    private float waitTime;

    public Transform movePos;
    public Transform LeftDownPos;
    public Transform RightUpPos;
    private Transform player;

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

        transform.position = Vector2.MoveTowards(transform.position, movePos.position, Speed * Time.deltaTime);

        if (ChangePosition < 0.1f)
        {
            if (waitTime <= 0)
            {
                movePos.position = GetRandomPos();
                flipTowardPlayer();
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }   
    }

    void flipTowardPlayer()
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

    void flip()
    {
        //Debug.Log("Turn");
        movingRight = !movingRight;
        transform.Rotate(0, -180, 0);
    }

    Vector2 GetRandomPos()
    {
        Vector2 rndPos = new Vector2(Random.Range(RightUpPos.position.x, LeftDownPos.position.x), Random.Range(RightUpPos.position.y, LeftDownPos.position.y));
        return rndPos;
    }
}
