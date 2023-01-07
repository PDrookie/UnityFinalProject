using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour
{
    [SerializeField] private Transform[] HPbar;
    [SerializeField] private Transform[] SkillImage;
    private bool[] SkillActive;
    [SerializeField] private Sprite BlackHeart;
    [SerializeField] private Sprite PinkHeart;
    [SerializeField] private GameObject DieImage;
    private GameObject Player;
    private PlayerAttributes PA;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        PA = Player.GetComponent<PlayerAttributes>();
        SkillActive = new bool[4];
    }

    // Update is called once per frame
    void Update()
    {
        switch (PA.HP)
        {
            case 0:
                HPbar[0].GetComponent<Image>().sprite = BlackHeart;
                HPbar[1].GetComponent<Image>().sprite = BlackHeart;
                HPbar[2].GetComponent<Image>().sprite = BlackHeart;
                HPbar[3].GetComponent<Image>().sprite = BlackHeart;
                HPbar[4].GetComponent<Image>().sprite = BlackHeart;
                Time.timeScale = 1;
                DieImage.SetActive(true);
                break;
            case 1:
                HPbar[0].GetComponent<Image>().sprite = PinkHeart;
                HPbar[1].GetComponent<Image>().sprite = BlackHeart;
                HPbar[2].GetComponent<Image>().sprite = BlackHeart;
                HPbar[3].GetComponent<Image>().sprite = BlackHeart;
                HPbar[4].GetComponent<Image>().sprite = BlackHeart;
                break;
            case 2:
                HPbar[0].GetComponent<Image>().sprite = PinkHeart;
                HPbar[1].GetComponent<Image>().sprite = PinkHeart;
                HPbar[2].GetComponent<Image>().sprite = BlackHeart;
                HPbar[3].GetComponent<Image>().sprite = BlackHeart;
                HPbar[4].GetComponent<Image>().sprite = BlackHeart;
                break;
            case 3:
                HPbar[0].GetComponent<Image>().sprite = PinkHeart;
                HPbar[1].GetComponent<Image>().sprite = PinkHeart;
                HPbar[2].GetComponent<Image>().sprite = PinkHeart;
                HPbar[3].GetComponent<Image>().sprite = BlackHeart;
                HPbar[4].GetComponent<Image>().sprite = BlackHeart;
                break;
            case 4:
                HPbar[0].GetComponent<Image>().sprite = PinkHeart;
                HPbar[1].GetComponent<Image>().sprite = PinkHeart;
                HPbar[2].GetComponent<Image>().sprite = PinkHeart;
                HPbar[3].GetComponent<Image>().sprite = PinkHeart;
                HPbar[4].GetComponent<Image>().sprite = BlackHeart;
                break;
            case 5:
                HPbar[0].GetComponent<Image>().sprite = PinkHeart;
                HPbar[1].GetComponent<Image>().sprite = PinkHeart;
                HPbar[2].GetComponent<Image>().sprite = PinkHeart;
                HPbar[3].GetComponent<Image>().sprite = PinkHeart;
                HPbar[4].GetComponent<Image>().sprite = PinkHeart;
                break;
            default:
                HPbar[0].GetComponent<Image>().sprite = BlackHeart;
                HPbar[1].GetComponent<Image>().sprite = BlackHeart;
                HPbar[2].GetComponent<Image>().sprite = BlackHeart;
                HPbar[3].GetComponent<Image>().sprite = BlackHeart;
                HPbar[4].GetComponent<Image>().sprite = BlackHeart;
                break;
        }
        if (PA.SU.active)
        {
            SkillActive[0] = true;
        }
        if (PA.AU.active)
        {
            SkillActive[1] = true;
        }
        if (PA.I.active)
        {
            SkillActive[2] = true;
        }
        if (PA.H.active)
        {
            SkillActive[3] = true;
        }
        for(int i = 0 ,m = 0; i < 4; i++)
        {
            if (SkillActive[i])
            {
                SkillImage[i].gameObject.SetActive(true);
                SkillImage[i].localPosition = new Vector2(-357 + (65 * m), -140);
                m++;
            }
        }
    }
}
