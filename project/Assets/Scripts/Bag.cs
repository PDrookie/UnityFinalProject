using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Bag : MonoBehaviour
{
    [SerializeField] private Sprite NorSpeed;
    [SerializeField] private Sprite NorATK;
    [SerializeField] private Sprite NorInvi;
    [SerializeField] private Sprite NorHeal;

    [SerializeField] private Sprite BlackSpeed;
    [SerializeField] private Sprite BlackATK;
    [SerializeField] private Sprite BlackInvi;
    [SerializeField] private Sprite BlackHeal;

    [SerializeField]private Transform bag;
    private PlayerAttributes PA;
    private TMP_Text MoneyDisplayer;
    private GameObject Speed;
    private GameObject ATK;
    private GameObject HEal;
    private GameObject In;
    // Start is called before the first frame update
    void Start()
    {
        PA = GameObject.Find("Player").GetComponent<PlayerAttributes>();
        MoneyDisplayer = bag.transform.Find("MoneyDisplayer").GetComponent<TMP_Text>();
        Speed = bag.transform.Find("Speed").gameObject;
        ATK = bag.transform.Find("ATK").gameObject;
        HEal = bag.transform.Find("Heal").gameObject;
        In =bag.transform.Find("Invincible").gameObject;
        MoneyDisplayer.text = PA.Coins.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        MoneyDisplayer.text = PA.Coins.ToString();

        if (PA.SU.active)
        {
            Speed.GetComponent<Image>().sprite = NorSpeed;
        }
        else
        {
            Speed.GetComponent<Image>().sprite = BlackSpeed;
        }

        if (PA.AU.active)
        {
            ATK.GetComponent<Image>().sprite = NorATK;
        }
        else
        {
            ATK.GetComponent<Image>().sprite = BlackATK;
        }

        if (PA.H.active)
        {
            HEal.GetComponent<Image>().sprite = NorHeal;
        }
        else
        {
            HEal.GetComponent<Image>().sprite = BlackHeal;
        }

        if (PA.I.active)
        {
            In.GetComponent<Image>().sprite = NorInvi;
        }
        else
        {
            In.GetComponent<Image>().sprite = BlackInvi;
        }

        if (Input.GetKeyDown(KeyCode.Tab) && !bag.gameObject.activeInHierarchy)
        {
            bag.gameObject.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && bag.gameObject.activeInHierarchy)
        {
            bag.gameObject.SetActive(false);
        }
        if (!bag.gameObject.activeInHierarchy)
        {
            return;
        }
    }
}
