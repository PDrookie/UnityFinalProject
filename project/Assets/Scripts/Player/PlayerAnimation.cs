using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerAnimation : MonoBehaviour
{
    private Animator PlayerAni;
    private Rigidbody2D PlayerRB;
    private PlayerMove PM;
    // Start is called before the first frame update
    void Start()
    {
        PlayerAni = transform.GetComponent<Animator>();
        PlayerRB = transform.GetComponent<Rigidbody2D>();
        PM = transform.GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PM.HorizontalMove == 0)
        {
            PlayerAni.SetInteger("speed", 0);
        }
        else
        {
            PlayerAni.SetInteger("speed", 1);
        }
        if (PM.IsJumping)
        {
            PlayerAni.SetBool("IsJump", true);
        }
        else if (!PM.IsJumping)
        {
            PlayerAni.SetBool("IsJump", false);
        }

    }
}
