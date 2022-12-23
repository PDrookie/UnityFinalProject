using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeBtn : MonoBehaviour
{
    // Start is called before the first frame update
    public void Click()
    {
        Time.timeScale = 1;
        GameObject.Find("Stop").SetActive(false);
        GameObject.Find("Main Camera").GetComponent<RapidBlurEffect>().enabled = false;
    }

}
