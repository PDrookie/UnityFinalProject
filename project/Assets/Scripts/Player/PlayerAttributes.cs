using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponConstants
{
    public const int Sword = 0;
    public const int Hammer = 1;
    public const int Sycthe = 2;
    public const int Rifle = 3;
}
public class PlayerAttributes : MonoBehaviour
{
    [SerializeField] private int HP;
    [SerializeField] private int[] ATKs;
    [SerializeField] private int DEX;
    [SerializeField] private int DEF;
    private bool doubleJump;
    private int multiple_ATK;
    public int TakingWeapon;
    private int HavingWeapon;
    public int PlayerAtk;

    private bool DoubleJump
    {
        get { return doubleJump; }
        set
        {
            if (value && !doubleJump)
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
        TakingWeapon = WeaponConstants.Sword;
        multiple_ATK = 1;
        PlayerAtk = multiple_ATK * ATKs[TakingWeapon];
    }

    // Update is called once per frame
    void Update()
    {
        PlayerAtk = multiple_ATK * ATKs[TakingWeapon];
        if (Input.GetKeyDown(KeyCode.E))
        {
            DoubleJump = true;
        }
    }
}
