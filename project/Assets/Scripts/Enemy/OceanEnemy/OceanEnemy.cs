using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanEnemy : MonoBehaviour
{
    public int Health;
    public int EnemyCauseDamage;

    public float flashTime;

    private SpriteRenderer sr;
    private Color originalColor;
    private PlayerMove PM;

    [Header("drop")]
    [SerializeField] private GameObject collection;
    [SerializeField] private int DropNumber;

    // Start is called before the first frame update
    public void Start()
    {
        PM = GetComponent<PlayerMove>();
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
        //gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
    }

    // Update is called once per frame
    public void Update()
    {


        if (Health <= 0)
        {
            Destroy(gameObject);
            for(int i = 0; i < DropNumber; i++)
            {
                int RanX = Random.Range(-3, 3);
                int RanY = Random.Range(-3, 3);
                Vector2 colletionPos = new Vector2(transform.position.x + RanX, transform.position.y + RanY);
                Instantiate(collection, colletionPos, Quaternion.identity);
            }
        }
    }

    public void takeDamage(int damage)
    {
        Health -= damage;
        flashColor(flashTime);
    }

    private void ResetColor()
    {
        sr.color = originalColor;
    }

    void flashColor(float time)
    {
        sr.color = Color.yellow;
        Invoke("ResetColor", time);
    }
}
