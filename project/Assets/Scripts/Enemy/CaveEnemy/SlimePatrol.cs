using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimePatrol : MonoBehaviour
{
    [Header("Pos")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header("Animator")]
    [SerializeField]private Animator animator;

    private void Awake()
    {
        initScale = enemy.localScale;
    }

    private void OnDisable()
    {
        animator.SetBool("Walk", false);
    }

    private void Update()
    {
        if(enemy == null)
        {
            return;
        }
        if (movingLeft)
        {
            if(enemy.position.x >= leftEdge.position.x)    //¦³°ÝÃD
                MoveInDirection(-1);
            else
            {
                DirectionChaneged();
            }
        }
        else
        {
            if(enemy.position.x <= rightEdge.position.x)
                MoveInDirection(1);
            else
            {
                DirectionChaneged();
            }
        }
    }

    private void DirectionChaneged()
    {
        animator.SetBool("Walk", false);

        idleTimer += Time.deltaTime;

        if(idleTimer > idleDuration)
        {
            movingLeft = !movingLeft;
        }

    }

    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;
        animator.SetBool("Walk", true);

        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, initScale.y, initScale.z);
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed, enemy.position.y, enemy.position.z);
    }
}
