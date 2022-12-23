using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            Time.timeScale = 0;
            GameObject.Find("Stop").SetActive(true);
            GameObject.Find("Main Camera").GetComponent<RapidBlurEffect>().enabled = true;
        }
    }
}
