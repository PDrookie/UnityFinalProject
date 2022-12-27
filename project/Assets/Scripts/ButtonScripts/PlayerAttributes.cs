using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    
    [SerializeField]private int HP;
    [SerializeField]private int ATK;
    [SerializeField]private int DEX;
    [SerializeField]private int DEF;
    private bool doubleJump;
    private bool DoubleJump
    {
        get { return doubleJump; }
        set
        {
            if(value && !doubleJump)
            {
                transform.GetComponent<PlayerMove>().MaxJumpTime = 2;
            }
            doubleJump = value;
            
        }
    }
    private bool dash;
    private bool Dash
    {
        get { return dash; }
        set
        {
            if (value && !dash)
            {
                transform.GetComponent<PlayerMove>().MaxJumpTime = 2;
            }
            dash = value;

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Dash = false;
        DoubleJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
