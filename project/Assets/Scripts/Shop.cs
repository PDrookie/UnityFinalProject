using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject ShopPanel;
    [SerializeField] private GameObject DialogBox;
    [SerializeField] private float ChooseImageYpos;
    private bool inShop;
    private Transform Glass;
    private int GlassOnWhich;
    // Start is called before the first frame update
    void Start()
    {
        inShop = false;
        Glass = ShopPanel.transform.Find("glass");
    }

    // Update is called once per frame
    void Update()
    {
        if(DialogBox.activeInHierarchy && Input.GetKeyDown(KeyCode.T) && !inShop)
        {
            Time.timeScale = 0;
            ShopPanel.SetActive(true);
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
        else if(inShop && Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1;
            ShopPanel.SetActive(false);
            inShop = false;
        }
    }
}
