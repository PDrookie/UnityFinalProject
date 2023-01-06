using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    [SerializeField] private GameObject SwitchPanel;
    [SerializeField] private GameObject DialogBox;

    void Start()
    {
        
    }

    void Update()
    {
        if(DialogBox.activeInHierarchy && Input.GetKeyDown(KeyCode.T))
        {
            Time.timeScale = 0;
            SwitchPanel.SetActive(true);
        }
    }
}
