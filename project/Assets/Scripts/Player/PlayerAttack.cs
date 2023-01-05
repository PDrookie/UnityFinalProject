using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerAttack : MonoBehaviour
{
    public bool IsAttack;
    private Animator PlayerAni;
    private Animator WeaponAni;
    private float TimeCounter;
    private Transform weapon;
    private PlayerAttributes PA;
    // Start is called before the first frame update
    void Start()
    {
        PlayerAni = transform.GetComponent<Animator>();
        PA = transform.GetComponent<PlayerAttributes>();
        IsAttack = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            weapon = transform.GetChild(PA.TakingWeapon + 1);
            PlayerAni.SetInteger("WeaponList", PA.TakingWeapon);
            weapon.gameObject.SetActive(true);
            WeaponAni = weapon.GetComponent<Animator>();
            WeaponAni.SetBool("IsAttack", true);
            IsAttack = true;
            PlayerAni.SetBool("IsAttack", true);
        }
    }
}
