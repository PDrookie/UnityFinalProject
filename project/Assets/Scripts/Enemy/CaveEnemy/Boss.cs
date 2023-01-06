using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private GameObject Enemy;
    [SerializeField] private GameObject Folder;
    private bool BossTrigger;
    public bool bossTriger
    {
        get
        {
            return BossTrigger;
        }
        set
        {
            if (value)
            {
                spawn();
            }
            BossTrigger = value;
        }
    }
    void spawn()
    {
        GameObject G = Instantiate(Enemy, transform.position , transform.rotation , Folder.transform);
    }
}
