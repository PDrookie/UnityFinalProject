using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject ShopPanel;
    [SerializeField] private GameObject DialogBox;
    
    [SerializeField] private float ChooseImageYpos;
    private bool inShop;
    private Transform Glass;
    private int GlassOnWhich;
    private TMP_Text MoneyDisplayer;
    private PlayerAttributes PA;

    [SerializeField] private Sprite HamSoldOut;
    [SerializeField] private Sprite ScySoldOut;
    [SerializeField] private Sprite SpeedSoldOut;
    [SerializeField] private Sprite ATKSoldOut;
    [SerializeField] private Sprite HealSoldOut;
    [SerializeField] private Sprite VinSoldOut;

    [SerializeField] private int HamPrice;
    [SerializeField] private int ScyPrice;
    [SerializeField] private int SpeedPrice;
    [SerializeField] private int ATKPrice;
    [SerializeField] private int HealPrice;
    [SerializeField] private int VinPrice;

    // Start is called before the first frame update
    void Start()
    {
        inShop = false;
        PA = GameObject.Find("Player").GetComponent<PlayerAttributes>();
        MoneyDisplayer = ShopPanel.transform.Find("MoneyDisplayer").GetComponent<TMP_Text>();
        Glass = ShopPanel.transform.Find("glass");
    }

    // Update is called once per frame
    void Update()
    {
        if(DialogBox.activeInHierarchy && Input.GetKeyDown(KeyCode.T) && !inShop)
        {
            Time.timeScale = 0;
            ShopPanel.SetActive(true);
            MoneyDisplayer.text = PA.Coins.ToString();
            inShop = true;
        }
        else if(inShop && Input.GetKeyDown(KeyCode.W))
        {
            GlassOnWhich -= 1;
            GlassOnWhich = Mathf.Clamp(GlassOnWhich, 0, 5);
            Glass.position = new Vector2(Glass.position.x, ShopPanel.transform.GetChild(GlassOnWhich).position.y);
        }
        else if (inShop && Input.GetKeyDown(KeyCode.S))
        {
            GlassOnWhich += 1;
            GlassOnWhich = Mathf.Clamp(GlassOnWhich, 0, 5);
            Glass.position = new Vector2(Glass.position.x, ShopPanel.transform.GetChild(GlassOnWhich).position.y);
        }
        else if(inShop && Input.GetKeyDown(KeyCode.Return))
        {
            switch (GlassOnWhich)
            {
                case 0:
                    if (!PA.HavingWeapon[1] && PA.Coins >= HamPrice)
                    {
                        PA.HavingWeapon[1] = true;
                        transform.GetChild(2).GetChild(0).GetComponent<Image>().sprite = HamSoldOut;
                        PA.Coins -= HamPrice;
                    }
                    break;
                case 1:
                    if (!PA.HavingWeapon[2] && PA.Coins >= ScyPrice)
                    {
                        PA.HavingWeapon[2] = true;
                        transform.GetChild(2).GetChild(1).GetComponent<Image>().sprite = ScySoldOut;
                        PA.Coins -= ScyPrice;
                    }
                    break;
                case 2:
                    if (!PA.SU.active && PA.Coins >= SpeedPrice)
                    {
                        PA.SU.active = true;
                        transform.GetChild(2).GetChild(2).GetComponent<Image>().sprite = SpeedSoldOut;
                        PA.Coins -= SpeedPrice;
                    }
                    break;
                case 3:
                    if (!PA.AU.active && PA.Coins >= ATKPrice)
                    {
                        PA.AU.active = true;
                        transform.GetChild(2).GetChild(3).GetComponent<Image>().sprite = ATKSoldOut;
                        PA.Coins -= ATKPrice;
                    }
                    break;
                case 4:
                    if (!PA.I.active && PA.Coins >= VinPrice)
                    {
                        PA.I.active = true;
                        transform.GetChild(2).GetChild(4).GetComponent<Image>().sprite = VinSoldOut;
                        PA.Coins -= VinPrice;
                    }
                    break;
                case 5:
                    if (!PA.H.active && PA.Coins >= HealPrice)
                    {
                        PA.H.active = true;
                        transform.GetChild(2).GetChild(5).GetComponent<Image>().sprite = HealSoldOut;
                        PA.Coins -= HealPrice;
                    }
                    break;
                default:
                    break;
            }
        }
        else if(inShop && Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1;
            ShopPanel.SetActive(false);
            inShop = false;
        }
    }
}
