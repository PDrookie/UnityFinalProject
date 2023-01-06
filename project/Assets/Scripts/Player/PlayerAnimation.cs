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
        if (transform.position.y < -45)
        {
            PlayerAni.SetBool("InOcean", true);
        }
        else
        {
            PlayerAni.SetBool("InOcean", false);
        }
        if (PM.IsHited)
        {
            PlayerAni.SetBool("IsHit", true);
        }
        else if (!PM.IsHited)
        {
            //PlayerAni.SetBool("IsHit", false);
        }
        if (PM.HorizontalMove == 0)
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
    void HitFinish()
    {
        //Debug.Log("...");
        PlayerAni.SetBool("IsHit", false);
    }
}
