using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Constants
{
    public const int MapSize = 5;
}
public class SwitchCamera : MonoBehaviour
{
    [SerializeField] private CustomArrays[] CamArray; //default 5x5 Array
    [SerializeField] private Transform Player;
    private float PlayerX;
    private float DistanceX;
    private Camera CamNow;
    int CamNowLocationX;
    int CamNowLocationY;
    void Start()
    {
        PlayerX = Player.position.x;
        CamNow = CamArray[(Constants.MapSize + 1) / 2][(Constants.MapSize + 1) / 2];
        CamNowLocationX = (Constants.MapSize + 1) / 2;
        CamNowLocationY = (Constants.MapSize + 1) / 2;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        PlayerX = Player.position.x;
        DistanceX = PlayerX - CamNow.transform.position.x;
        Debug.Log(DistanceX);
        if (DistanceX > 11.4)
        {
            CamArray[CamNowLocationX][CamNowLocationY].gameObject.SetActive(false);
            CamArray[CamNowLocationX + 1][CamNowLocationY].gameObject.SetActive(true);
            CamNow = CamArray[CamNowLocationX + 1][CamNowLocationY];
            CamNowLocationX++;
        }
        else if (DistanceX < -11.4)
        {
            CamArray[CamNowLocationX][CamNowLocationY].gameObject.SetActive(false);
            CamArray[CamNowLocationX - 1][CamNowLocationY].gameObject.SetActive(true);
            CamNow = CamArray[CamNowLocationX - 1][CamNowLocationY];
            CamNowLocationX--;
        }
    }
}
[System.Serializable]
public class CustomArrays
{
    public Camera[] Array;
    public Camera this[int index]
    {
        get
        {
            return Array[index];
        }
    }
}
