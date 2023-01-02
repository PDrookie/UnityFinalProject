using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField]private GameObject ShopPanel;
    [SerializeField]private GameObject DialogBox;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(DialogBox.activeInHierarchy && Input.GetKeyDown(KeyCode.T))
        {
            ShopPanel.SetActive(true);
        }
    }
}
