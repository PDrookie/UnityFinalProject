using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    private Transform[] Spawners;

    [SerializeField]
    private GameObject Enemy;

    private void Start()
    {
        Spawner();
    }

    private void Spawner()
    {
        for(int i = 0; i < Spawners.Length; i++)
        {
            Instantiate(Enemy, Spawners[i].position, Spawners[i].rotation);
        }
    }

}
