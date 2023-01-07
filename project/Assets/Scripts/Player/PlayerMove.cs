using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    #region
    public static Transform instance;
    #endregion

    [SerializeField] private Vector3 InitailPos;

    [SerializeField] private LayerMask LM;
    [SerializeField] private Transform Checkpoint;
    [SerializeField] private string AirWallTag;

    public float MoveSpeed;
    [SerializeField] private float JumpForce;
    [SerializeField] private float WallJumpXForce;
    [SerializeField] private float SlideGravity;

    private Rigidbody2D RB;
    private int JumpCount;
    private bool SpacePress;
    private bool NotOnWallOrSkill;
    public bool IsJumping;
    public int MaxJumpTime;
    public bool IsHited;
    private float NormalGravity;
    public float HorizontalMove;
    public float VerticalMove;
    private bool Ground;
    private bool Ocean;

    private void Awake()
    {
        instance = this.transform;
    }

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
        MaxJumpTime = 2;                            //DEFAULT INI
        JumpCount = MaxJumpTime;
        IsHited = false;
        //transform.position = InitailPos;  
    }

    void Update()
    {
        if (transform.position.y < -45)
        {
            Ground = false;
            Ocean = true;
        }
        else
        {
            Ground = true;
            Ocean = false;
        }
        if (Ground)
        {
            if (Input.GetButtonDown("Jump") && JumpCount > 0)
            {
                SpacePress = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (Ground)
        {
            if (IsHited)
            {
                return;
            }
            IsJumping = !Physics2D.OverlapCircle(Checkpoint.position, 0.3f, LM);
            if (!IsJumping)
            {
                JumpCount = MaxJumpTime;
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
        else if (Ocean)
        {
            HorizontalMovement();
            VerticalMovement();
            RB.gravityScale = 0;
        }
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
            JumpCount = MaxJumpTime;
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
            if (Physics2D.OverlapCircle(Checkpoint.position, 0.3f, LM))
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

        if (HorizontalMove > 0)
        {
            transform.localScale = new Vector3(-1.692233f, transform.localScale.y, 1);
        }
        else if (HorizontalMove < 0)
        {
            transform.localScale = new Vector3(1.692233f, transform.localScale.y, 1);
        }
    }

    void VerticalMovement()
    {
        VerticalMove = Input.GetAxisRaw("Vertical");
        RB.velocity = new Vector2(RB.velocity.x, VerticalMove * MoveSpeed);
    }

    void jump()
    {
        if (SpacePress && JumpCount == MaxJumpTime)
        {
            IsJumping = true;
            RB.velocity = new Vector2(RB.velocity.x, JumpForce);
            JumpCount--;
            SpacePress = false;
        }
        else if (SpacePress && IsJumping && JumpCount > 0)
        {
            RB.velocity = new Vector2(RB.velocity.x, JumpForce);
            JumpCount--;
            SpacePress = false;
        }
    }

    void WallJump(int RightOrLeft)
    {
        if (JumpCount > 0 && WallTrigger.OnWall && SpacePress)
        {
            IsJumping = true;
            RB.velocity = new Vector2(WallJumpXForce * RightOrLeft, JumpForce);
            JumpCount--;
            SpacePress = false;
        }
    }
}