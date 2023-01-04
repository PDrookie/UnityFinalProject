using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    public GameObject collectable;
    private int AllowOpenTimes;
    private int Calculate;
    private bool CoinAppear = false;
    private float WaitingTime = 1.5f;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        AllowOpenTimes = Random.Range(4, 8);
        Calculate = AllowOpenTimes;
    }

    private void Update()
    {
        if (CoinAppear)
        {
            WaitingTime -= Time.deltaTime;
            if(WaitingTime <= 0.5f)
            {
                for (int i = 0; i < AllowOpenTimes; i++)
                {
                    int PosY = Random.Range(0, 3);
                    Vector2 CoinPos = new Vector2(transform.position.x, transform.position.y + PosY);
                    Instantiate(collectable, CoinPos, Quaternion.identity);
                }
                CoinAppear = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "weapon")
        {
            Calculate--;
            //Debug.Log(Calculate);
            if(Calculate == 0)
            {
                animator.SetTrigger("Open");
                Destroy(gameObject, 1f);
                CoinAppear = true;
            }
        }
    }
}
