using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour
{
    [SerializeField]private Transform bag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !bag.gameObject.activeInHierarchy)
        {
            bag.gameObject.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && bag.gameObject.activeInHierarchy)
        {
            bag.gameObject.SetActive(false);
        }
    }
}
