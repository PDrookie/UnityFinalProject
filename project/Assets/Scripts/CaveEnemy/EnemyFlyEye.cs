using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlyEye : CaveEnemy
{
    public float Speed;
    public float startWaitTime;
    private float waitTime;

    public Transform movePos;
    public Transform LeftDownPos;
    public Transform RightUpPos;


    // Start is called before the first frame update
    public void Start()
    {
        base.Start();

        waitTime = startWaitTime;
        movePos.position = GetRandomPos();
    }

    // Update is called once per frame
    public void Update()
    {
        base.Update();

        transform.position = Vector2.MoveTowards(transform.position, movePos.position, Speed * Time.deltaTime);
        if(Vector2.Distance(transform.position, movePos.position) < 0.1f)
        {
            if(waitTime <= 0)
            {
                movePos.position = GetRandomPos();
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    Vector2 GetRandomPos()
    {
        Vector2 rndPos = new Vector2(Random.Range(RightUpPos.position.x, LeftDownPos.position.x), Random.Range(RightUpPos.position.y, LeftDownPos.position.y));
        return rndPos;
    }
}
