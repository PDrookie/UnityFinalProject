using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CaveEnemy : MonoBehaviour
{
    public int Health;
    public int Damage;

    public float flashTime;

    private SpriteRenderer sr;
    private Color originalColor;

    // Start is called before the first frame update
    public void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
    }

    // Update is called once per frame
    public void Update()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
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
        sr.color = Color.red;
        Invoke("ResetColor", time);
    }
}
