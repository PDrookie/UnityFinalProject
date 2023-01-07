using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    private GameObject maincamera;
    private bool ESCpress;
    // Start is called before the first frame update
    private void Start()
    {
        maincamera = GameObject.Find("Main Camera");
        ESCpress = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !ESCpress)
        {
            ESCpress = true;
            Time.timeScale = 0;
            panel.SetActive(true);
            maincamera.GetComponent<RapidBlurEffect>().enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.P) && ESCpress)
        {
            ESCpress = false;
            Time.timeScale = 1;
            panel.SetActive(false);
            maincamera.GetComponent<RapidBlurEffect>().enabled = false;
        }
    }
}
