using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Soil : MonoBehaviour
{
    static public Dictionary<int,Sprite> levelImg=new Dictionary<int,Sprite>();
    [SerializeField]
    Sprite []img;
    // Start is called before the first frame update
    void Start()
    {
        try{
            for(int i=0;i<3;i++){
                levelImg.Add(i,img[i]);
            }
        }catch(ArgumentException ex){
            ;
        }
    }
}
