using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject Player;
    // Start is called before the first frame update
    
    void Awake()
    { 
        try{
            Player = GameObject.FindGameObjectWithTag("Player");
            GameObject[] mainCameras = GameObject.FindGameObjectsWithTag("MainCamera");
            if (mainCameras.Length == 1)
            {
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            } // 중복된 MainCamera 오브젝트가 있을 경우 오브젝트 파괴
        }catch (NullReferenceException e) {
            ;
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        try{
            this.transform.position = new Vector3(Player.transform.position.x , Player.transform.position.y,-50);
        }catch (NullReferenceException e) {
            ;
        }
    }
}
