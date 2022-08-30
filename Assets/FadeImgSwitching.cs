using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeImgSwitching : MonoBehaviour
{

    [SerializeField]
    Sprite sr;

    // Start is called before the first frame update
    void Start()
    {
        try{
            if(sr!=null){
                this.GetComponent<SpriteRenderer>().sprite=sr;
            }
        }catch(MissingComponentException e){

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
