using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    private Transform[] Spawners;

    [SerializeField]
    private GameObject Enemy;

    [SerializeField]
    private GameObject EnemyFolder;

    private void Start()
    {
        Spawner();
    }

    private void Spawner()
    {
        for(int i = 0; i < Spawners.Length; i++)
        {
            GameObject Monsters = Instantiate(Enemy, Spawners[i].position, Spawners[i].rotation,EnemyFolder.transform);
            Monsters.transform.tag = "Enemy";
            
            //Monsters.AddComponent<CapsuleCollider2D>();
            //Monsters.GetComponent<CapsuleCollider2D>().isTrigger = true;
        }
    }

}
