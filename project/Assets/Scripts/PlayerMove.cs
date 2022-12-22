using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Vector3 InitailPos;

    [SerializeField] private LayerMask LM;
    [SerializeField] private Transform Checkpoint;
    [SerializeField] private string AirWallTag;
    [SerializeField] private int MaxJumpCount;
    [SerializeField] private float MoveSpeed;
    [SerializeField] private float JumpForce;
    [SerializeField] private float WallJumpXForce;
    [SerializeField] private float SlideGravity;
    private Rigidbody2D RB;
    private bool SpacePress;
    private bool NotOnWallOrSkill;
    private bool IsJumping;
    private int JumpCount;
    private float NormalGravity;
    private float HorizontalMove;
    private struct _WallTrigger
    {
        public bool OnWall;
        public int WallDirection;    //Right = -1,Left = 1
    }
    private _WallTrigger WallTrigger;
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        NormalGravity = RB.gravityScale;
        NotOnWallOrSkill = true;
        WallTrigger.OnWall = false;
        WallTrigger.WallDirection = 0;
        IsJumping = false;

        JumpCount = MaxJumpCount;
        //transform.position = InitailPos;  
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && MaxJumpCount > 0)
        {
            SpacePress = true;
        }
    }

    private void FixedUpdate()
    {
        IsJumping = !Physics2D.OverlapCircle(Checkpoint.position, 0.1f, LM);
        if (!IsJumping)
        {
            MaxJumpCount = JumpCount;
        }
        if (WallTrigger.OnWall && RB.velocity.y < 0)
        {
            RB.gravityScale = SlideGravity;
            if (SpacePress)
            {
                WallJump(WallTrigger.WallDirection);
            }
            else
            {
                HorizontalMove = Input.GetAxisRaw("Horizontal");
                RB.velocity = new Vector2(HorizontalMove * MoveSpeed, RB.velocity.y);
            }
        }
        else
        {
            RB.gravityScale = NormalGravity;
            jump();
        }

        HorizontalMovement();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals(AirWallTag))
        {
            RB.velocity = new Vector2(0, 0);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.tag.Equals(AirWallTag))
        {
            MaxJumpCount = JumpCount;
            WallTrigger.OnWall = true;
            if (collision.transform.position.x < transform.position.x)
            {
                WallTrigger.WallDirection = 1;
            }
            else if (collision.transform.position.x >= transform.position.x)
            {
                WallTrigger.WallDirection = -1;
            }
            NotOnWallOrSkill = false;
            if (Physics2D.OverlapCircle(Checkpoint.position, 0.1f, LM))
            {
                NotOnWallOrSkill = true;
                WallTrigger.OnWall = false;
                WallTrigger.WallDirection = 0;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals(AirWallTag))
        {
            NotOnWallOrSkill = true;
            WallTrigger.OnWall = false;
            WallTrigger.WallDirection = 0;
        }
    }
    void HorizontalMovement()
    {
        HorizontalMove = Input.GetAxisRaw("Horizontal");
        if (NotOnWallOrSkill)
        {
            RB.velocity = new Vector2(HorizontalMove * MoveSpeed, RB.velocity.y);
        }

        if (HorizontalMove != 0)
        {
            if (HorizontalMove > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if(HorizontalMove < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }

    void jump()
    {
        if (SpacePress && MaxJumpCount == JumpCount)
        {
            IsJumping = true;
            RB.velocity = new Vector2(RB.velocity.x, JumpForce);
            MaxJumpCount--;
            SpacePress = false;
        }
        else if (SpacePress && IsJumping && MaxJumpCount > 0)
        {
            RB.velocity = new Vector2(RB.velocity.x, JumpForce);
            MaxJumpCount--;
            SpacePress = false;
        }
    }

    void WallJump(int RightOrLeft)
    {
        if (JumpCount > 0 && WallTrigger.OnWall)
        {
            IsJumping = true;
            RB.velocity = new Vector2(WallJumpXForce * RightOrLeft, JumpForce);
            MaxJumpCount--;
            SpacePress = false;
        }
    }
}