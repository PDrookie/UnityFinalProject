using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CamConstants
{
    public const int MapSize = 5;
}
public class SwitchCamera : MonoBehaviour
{
    //[SerializeField] private CustomArrays[] CamArray; //default 5x5 Array
    [SerializeField] private Transform Player;
    [SerializeField] private float HorCameraDistance;
    [SerializeField] private float VerCameraDistance;
    [SerializeField]private Camera MainCam;
    private float PlayerX;
    private float PlayerY;
    private float DistanceX;
    private float DistanceY;
    void Start()
    {
        Vector3 PlayerPos = Player.position;
        MainCam.transform.position = new Vector3(PlayerPos.x, PlayerPos.y, -8);
        PlayerX = Player.position.x;
        PlayerY = Player.position.y;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        PlayerX = Player.position.x;
        PlayerY = Player.position.y;
        DistanceX = PlayerX - MainCam.transform.position.x;
        DistanceY = PlayerY - MainCam.transform.position.y;
        MainCam.transform.position = new Vector3(Player.position.x, Player.position.y + 3, MainCam.transform.position.z);
        /*
        if (DistanceX > HorCameraDistance)
        {
            MainCam.transform.position = new Vector3(MainCam.transform.position.x + HorCameraDistance * 2, MainCam.transform.position.y, MainCam.transform.position.z);
        }
        else if (DistanceX < -HorCameraDistance)
        {
            MainCam.transform.position = new Vector3(MainCam.transform.position.x - HorCameraDistance * 2, MainCam.transform.position.y, MainCam.transform.position.z);
        }
        if (DistanceY > VerCameraDistance)
        {
            MainCam.transform.position = new Vector3(MainCam.transform.position.x, MainCam.transform.position.y + VerCameraDistance * 2, MainCam.transform.position.z);
        }
        else if (DistanceY < -VerCameraDistance)
        {
            MainCam.transform.position = new Vector3(MainCam.transform.position.x, MainCam.transform.position.y - VerCameraDistance * 2, MainCam.transform.position.z);
        }
        */
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
