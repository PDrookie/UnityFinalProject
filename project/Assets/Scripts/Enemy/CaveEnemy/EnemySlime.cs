using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlime : CaveEnemy
{

    private GameObject player;
    [SerializeField] private float attackCoolDown;
    [SerializeField] private float attackRange;
    [SerializeField] private float ColliderDistance;
    [SerializeField] private int damage;
    [SerializeField] private BoxCollider2D BoxCollider;
    [SerializeField] private LayerMask PlayerLayer;
    private float cooldowniTimer = Mathf.Infinity;

    private Animator animator;

    private SlimePatrol SlimePatrol; 

    private void Awake()
    {
        animator = GetComponent<Animator>();
        SlimePatrol = GetComponentInParent<SlimePatrol>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        base.Update();

        cooldowniTimer += Time.deltaTime;

        if (PlayerInSight())
        {
            Vector2 PlayerPos = new Vector2(player.transform.position.x, player.transform.position.y + 0.8f);
            transform.position = Vector2.MoveTowards(this.transform.position, PlayerPos, 2 * Time.deltaTime);

            if (cooldowniTimer >= attackCoolDown)
            {
                cooldowniTimer = 0;
                animator.SetTrigger("Attack");
            }
        }
        
        if(SlimePatrol != null)
        {
            SlimePatrol.enabled = !PlayerInSight(); 
        }

    }

    private bool PlayerInSight()
    {
        Vector3 BoundSize = new Vector3(BoxCollider.bounds.size.x * attackRange, BoxCollider.bounds.size.y, BoxCollider.bounds.size.z);
        RaycastHit2D hit = Physics2D.BoxCast(BoxCollider.bounds.center + transform.right * attackRange * transform.localScale.x * ColliderDistance,
            BoundSize, 0, Vector2.left, 0, PlayerLayer); 
        if(hit.collider != null)
        {
            //Player getDamage
        }

        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Vector3 BoundSize = new Vector3(BoxCollider.bounds.size.x * attackRange, BoxCollider.bounds.size.y, BoxCollider.bounds.size.z);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(BoxCollider.bounds.center + transform.right * attackRange * transform.localScale.x * ColliderDistance,
           BoundSize);
    }

    private void DamagePlayer()
    {
        if (PlayerInSight())
        {
            //Damage Player
        }
    }
}
