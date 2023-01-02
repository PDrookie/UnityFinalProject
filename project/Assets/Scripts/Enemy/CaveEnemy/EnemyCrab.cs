using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCrab : CaveEnemy
{
    public float Speed;
    public float waitTime;

    public Transform[] movePos;

    private int i = 0;
    private bool movingLeft = true;
    private float wait;

    // Start is called before the first frame update
    public void Start()
    {
        Health = 100;
        base.Start();
        wait = waitTime;
        //Debug.Log(transform.parent.name);
    }

    // Update is called once per frame
    public void Update()
    {
        base.Update();
        transform.position = Vector2.MoveTowards(transform.position, movePos[i].position, Speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, movePos[i].position) < 0.1f)
        {
            if (waitTime > 0)
            {
                waitTime -= Time.deltaTime;
            }
            else
            {
                if (movingLeft)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    movingLeft = false;
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    movingLeft = true;
                }
                if(i == 0)
                {
                    i = 1;
                }
                else
                {
                    i = 0;
                }
                waitTime = wait;
            }
        }
    }
}
