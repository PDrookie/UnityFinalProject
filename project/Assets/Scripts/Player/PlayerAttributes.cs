using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponConstants
{
    public const int Sword = 0;
    public const int Hammer = 1;
    public const int Sycthe = 2;
}

public class PlayerAttributes : MonoBehaviour
{
    public int HP = 5;
    public int Coins = 0;
    public int[] ATKs;

    [SerializeField] private int SpeedUpCD;
    [SerializeField] private int ATKUpCD;
    [SerializeField] private int HealCD;
    [SerializeField] private int InvincibleCD;

    [SerializeField] private int SpeedMul;
    [SerializeField] private int ATKMul;
    [SerializeField] private int HealNum;

    [SerializeField] private float SpeedUPContinueTime;
    [SerializeField] private float ATKUPContinueTime;
    [SerializeField] private float InvicibleContinueTime;

    private bool doubleJump;
    public int TakingWeapon;
    public bool[] HavingWeapon = new bool[4];
    public int PlayerAtk;

    private float SpeedTimeCounter;
    private float ATKTimeCounter;
    private float HealTimeCounter;
    private float InvicibleTimeCounter;

    public SpeedUp SU;
    public ATKUp AU;
    public Heal H;
    public Invincible I;
    GameObject Player;

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
    // Start is called before the first frame update
    void Start()
    {
        //���oplayer����
        Player = GameObject.Find("Player");
        //��l�ƥ[�t
        SU = new SpeedUp(Player);
        SU.SpeedMul = SpeedMul;
        SU.ContinueTime = SpeedUPContinueTime;
        SU.active = false;
        SU.inCD = false;
        SU._Using = false;
        SU.SetCD(SpeedUpCD);
        //��l�ƨg��
        AU = new ATKUp(Player);
        AU.ATKMul = ATKMul;
        AU.ContinueTime = ATKUPContinueTime;
        AU.active = false;
        AU._Using = false;
        AU.inCD = false;
        AU.SetCD(ATKUpCD);
        //��l�ƪv��
        H = new Heal(Player);
        H.HealNum = HealNum;
        H.active = false;
        H._Using = false;
        H.inCD = false;
        H.SetCD(HealCD);
        //��l�ƵL��
        I = new Invincible(Player);
        I.active = false;
        I._Using = false;
        I.inCD = false;
        I.ContinueTime = InvicibleContinueTime;
        I.SetCD(InvincibleCD);
        //��l�ƭp�ɾ�
        SpeedTimeCounter = 0;
        ATKTimeCounter = 0;
        HealTimeCounter = 0;
        InvicibleTimeCounter = 0;

        DoubleJump = false;
        HavingWeapon[0] = true;
        TakingWeapon = WeaponConstants.Sword;
    }

    // Update is called once per frame
    void Update()
    {
        if (SU.inCD || SU._Using)
        {
            SpeedTimeCounter += Time.deltaTime;
        }

        if (AU.inCD || AU._Using)
        {
            ATKTimeCounter += Time.deltaTime;
        }

        if (H.inCD)
        {
            HealTimeCounter += Time.deltaTime;
        }

        if (I.inCD)
        {
            InvicibleTimeCounter += Time.deltaTime;
        }

        
        if (Input.GetKeyDown(KeyCode.E))
        {
            DoubleJump = true;
        }

        //Speed�ޯ઺���A��
        if (SU.active && Input.GetKeyDown(KeyCode.Q) && !SU.inCD && !SU._Using)
        {
            SU._Using = true;
            SU.Effect();
            SpeedTimeCounter = 0;
        }
        else if (SU._Using && SpeedTimeCounter >= SU.ContinueTime && !SU.inCD && SU.active)
        {
            SU.Terminate();
            SpeedTimeCounter = 0;
            SU._Using = false;
            SU.inCD = true;
        }
        else if(SU.inCD && SpeedTimeCounter >= SU.CD && SU.active && !SU._Using)
        {
            SU.inCD = false;
        }

        //ATK�ޯ઺���A��
        if (AU.active && Input.GetKeyDown(KeyCode.W) && !AU.inCD && !AU._Using)
        {
            AU._Using = true;
            AU.Effect();
            ATKTimeCounter = 0;
        }
        else if (AU._Using && ATKTimeCounter >= AU.ContinueTime && !AU.inCD && AU.active)
        {
            AU.Terminate();
            ATKTimeCounter = 0;
            AU._Using = false;
            AU.inCD = true;
        }
        else if (AU.inCD && ATKTimeCounter >= AU.CD && AU.active && !AU._Using)
        {
            AU.inCD = false;
        }

        //Heal�ޯ઺���A��
        if (H.active && Input.GetKeyDown(KeyCode.E) && !H.inCD)
        {
            H.inCD = true;
            H.Effect();
            HP = Mathf.Clamp(HP, 0, 5);
            HealTimeCounter = 0;
        }
        else if (H.inCD && HealTimeCounter >= H.CD && H.active)
        { 
            H.inCD = false;
        }

        //�L�ħޯ઺���A��
        if (I.active && Input.GetKeyDown(KeyCode.W) && !I.inCD)
        {
            I.inCD = true;
            I.Effect();
            InvicibleTimeCounter = 0;
        }
        else if (I.inCD && InvicibleTimeCounter >= I.CD && I.active)
        {
            I.inCD = false;
        }
    }


}
public class SpeedUp : Skills
{
    GameObject Player;
    float OriginSpeed;
    public override void Effect()
    {
        OriginSpeed = Player.GetComponent<PlayerMove>().MoveSpeed;
        Player.GetComponent<PlayerMove>().MoveSpeed = OriginSpeed * SpeedMul;
    }

    public override void Terminate()
    {
        Player.GetComponent<PlayerMove>().MoveSpeed = OriginSpeed;
    }
    public SpeedUp(GameObject G)
    {
        Player = G;
    }
}

public class ATKUp : Skills
{
    GameObject Player;
    int OriginATK;
    public override void Effect()
    {
        int OriginATK = Player.GetComponent<PlayerAttributes>().PlayerAtk;
        Player.GetComponent<PlayerAttributes>().PlayerAtk = OriginATK * ATKMul;
    }
    public override void Terminate()
    {
        Player.GetComponent<PlayerAttributes>().PlayerAtk = OriginATK;
    }
    public ATKUp(GameObject G)
    {
        Player = G;
    }
}

public class Heal : Skills
{
    GameObject Player;
    public override void Effect()
    {
        Player.GetComponent<PlayerAttributes>().HP += HealNum;
    }
    public override void Terminate()
    {
        ;
    }
    public Heal(GameObject G)
    {
        Player = G;
    }
}

public class Invincible : Skills
{
    GameObject Player;
    public override void Effect()
    {

        //��@�L��
    }
    public override void Terminate()
    {
        ;
    }
    public Invincible(GameObject G)
    {
        Player = G;
    }
}
