using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroCloseBtn : MonoBehaviour
{
    [SerializeField] private GameObject Btns;
    [SerializeField] private GameObject Intro;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Click()
    {
        Btns.SetActive(true);
        Intro.SetActive(false);
    }
}
