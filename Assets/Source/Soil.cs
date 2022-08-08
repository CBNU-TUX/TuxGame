using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Soil : MonoBehaviour
{
    static public Dictionary<int,Sprite> levelImg;
    
    [SerializeField]
    Sprite []img;
    // Start is called before the first frame update
    void Awake()
    {
        levelImg=new Dictionary<int,Sprite>();
        try{
            for(int i=0;i<img.Length;i++){
                levelImg.Add(i,img[i]);
            }
        }catch(ArgumentException ex){
            ;
        }
    }
}
