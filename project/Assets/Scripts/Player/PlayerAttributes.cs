using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField] private Sprite NorSpeed;
    [SerializeField] private Sprite NorATK;
    [SerializeField] private Sprite NorInvi;
    [SerializeField] private Sprite NorHeal;

    [SerializeField] private Sprite BlackSpeed;
    [SerializeField] private Sprite BlackATK;
    [SerializeField] private Sprite BlackInvi;
    [SerializeField] private Sprite BlackHeal;

    [SerializeField]private GameObject Speed;
    [SerializeField]private GameObject ATK;
    [SerializeField]private GameObject Invi;
    [SerializeField]private GameObject Heal;
    [SerializeField] private GameObject Shop;

    private bool doubleJump;
    public int TakingWeapon;
    public bool[] HavingWeapon = new bool[3];
    public int PlayerAtk;

    private float SpeedTimeCounter;
    private float ATKTimeCounter;
    private float HealTimeCounter;
    private float InvicibleTimeCounter;

    public bool _Invicible;
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
        //取得player物件
        Player = GameObject.Find("Player");
        //初始化加速
        SU = new SpeedUp(Player);
        SU.SpeedMul = SpeedMul;
        SU.ContinueTime = SpeedUPContinueTime;
        SU.active = false;
        SU.inCD = false;
        SU._Using = false;
        SU.SetCD(SpeedUpCD);
        //初始化狂暴
        AU = new ATKUp(Player);
        AU.ATKMul = ATKMul;
        AU.ContinueTime = ATKUPContinueTime;
        AU.active = false;
        AU._Using = false;
        AU.inCD = false;
        AU.SetCD(ATKUpCD);
        //初始化治療
        H = new Heal(Player);
        H.HealNum = HealNum;
        H.active = false;
        H._Using = false;
        H.inCD = false;
        H.SetCD(HealCD);
        //初始化無敵
        I = new Invincible(Player);
        I.active = false;
        I._Using = false;
        I.inCD = false;
        I.ContinueTime = InvicibleContinueTime;
        I.SetCD(InvincibleCD);
        //初始化計時器
        SpeedTimeCounter = 0;
        ATKTimeCounter = 0;
        HealTimeCounter = 0;
        InvicibleTimeCounter = 0;

        _Invicible = false;
        DoubleJump = true;
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

        //Speed技能的狀態機
        if (SU.active && Input.GetKeyDown(KeyCode.Q) && !SU.inCD && !SU._Using && !Shop.activeInHierarchy)
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
            Speed.GetComponent<Image>().sprite = BlackSpeed;
        }
        else if(SU.inCD && SpeedTimeCounter >= SU.CD && SU.active && !SU._Using)
        {
            SU.inCD = false;
            Speed.GetComponent<Image>().sprite = NorSpeed;
        }

        //ATK技能的狀態機
        if (AU.active && Input.GetKeyDown(KeyCode.W) && !AU.inCD && !AU._Using && !Shop.activeInHierarchy)
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
            ATK.GetComponent<Image>().sprite = BlackATK;
        }
        else if (AU.inCD && ATKTimeCounter >= AU.CD && AU.active && !AU._Using)
        {
            AU.inCD = false;
            ATK.GetComponent<Image>().sprite = NorATK;
        }

        //Heal技能的狀態機
        if (H.active && Input.GetKeyDown(KeyCode.R) && !H.inCD && !Shop.activeInHierarchy)
        {
            H.inCD = true;
            H.Effect();
            HP = Mathf.Clamp(HP, 0, 5);
            HealTimeCounter = 0;
            Heal.GetComponent<Image>().sprite = BlackHeal;
        }
        else if (H.inCD && HealTimeCounter >= H.CD && H.active)
        { 
            H.inCD = false;
            Heal.GetComponent<Image>().sprite = NorHeal;
        }

        //無敵技能的狀態機
        if (I.active && Input.GetKeyDown(KeyCode.E) && !I.inCD && !Shop.activeInHierarchy)
        {
            I.inCD = true;
            I.Effect();
            InvicibleTimeCounter = 0;
            Invi.GetComponent<Image>().sprite = BlackInvi;
        }
        else if (I.inCD && InvicibleTimeCounter >= I.CD && I.active)
        {
            I.inCD = false;
            Invi.GetComponent<Image>().sprite = NorInvi;
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
        OriginATK = Player.GetComponent<PlayerAttributes>().PlayerAtk;
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
        Player.GetComponent<PlayerAttributes>()._Invicible = true;
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
