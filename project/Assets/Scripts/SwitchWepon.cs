using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchWepon : MonoBehaviour
{
    [SerializeField] private GameObject Sword;
    [SerializeField] private GameObject Hammer;
    [SerializeField] private GameObject Scyche;
    private GameObject[] Weapons;

    [SerializeField] private GameObject Glass;
    [SerializeField] private GameObject Thiss;

    [SerializeField] private Sprite NorSword;
    [SerializeField] private Sprite NorHammer;
    [SerializeField] private Sprite NorScyche;

    [SerializeField] private Sprite BlackSword;
    [SerializeField] private Sprite BlackHammer;
    [SerializeField] private Sprite BlackScyche;
    private PlayerAttributes PA;
    private int GlassOnWhich;

    // Start is called before the first frame update
    void Start()
    {
        Weapons = new GameObject[3];
        Weapons[0] = Sword;
        Weapons[1] = Hammer;
        Weapons[2] = Scyche;
        PA = GameObject.Find("Player").GetComponent<PlayerAttributes>();
        Glass.transform.position = Sword.transform.position;
        GlassOnWhich = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Thiss.activeInHierarchy)
        {
            return;
        }
        if (PA.HavingWeapon[0])
        {
            Sword.GetComponent<Image>().sprite = NorSword;
        }
        else
        {
            Sword.GetComponent<Image>().sprite = BlackSword;
        }
        if (PA.HavingWeapon[1])
        {
            Hammer.GetComponent<Image>().sprite = NorHammer;
        }
        else
        {
            Hammer.GetComponent<Image>().sprite = BlackHammer;
        }
        if (PA.HavingWeapon[2])
        {
            Scyche.GetComponent<Image>().sprite = NorScyche;
        }
        else
        {
            Scyche.GetComponent<Image>().sprite = BlackScyche;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            for (int i = GlassOnWhich - 1; i >= 0; i--)
            {
                if (PA.HavingWeapon[i])
                {
                    Glass.transform.position = new Vector2(Weapons[i].transform.position.x, Glass.transform.position.y);
                    GlassOnWhich = i;
                    break;
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            for (int i = GlassOnWhich + 1; i < 3; i++)
            {
                if (PA.HavingWeapon[i])
                {
                    Glass.transform.position = new Vector2(Weapons[i].transform.position.x, Glass.transform.position.y);
                    GlassOnWhich = i;
                    break;
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            PA.TakingWeapon = GlassOnWhich;
        }
    }
}
