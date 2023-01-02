using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;


public class WeaponAni : MonoBehaviour
{
    
    private Animator Ani;
    private Animator playerAni;
    // Start is called before the first frame update
    void Start()
    {
        playerAni = GameObject.Find("Player").GetComponent<Animator>();
        Ani = transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void AniFinish()
    {
        transform.gameObject.SetActive(false);
        Ani.SetBool("IsAttack", false);
        playerAni.SetBool("IsAttack", false);
    }
}
