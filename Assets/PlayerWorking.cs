using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerWorking : MonoBehaviour
{
    static public List<SoilInfo> working;
    // Start is called before the first frame update
    ClickController clickObject;
    void Start(){
        working=new List<SoilInfo>();
        clickObject = GameObject.FindObjectOfType<ClickController>();
    }

    void OnTriggerStay2D(Collider2D collision){
        try{
            SoilInfo tmp=collision.gameObject.GetComponent<SoilInfo>();
            if(clickObject.click.name=="BoxUI01"&&clickObject.click!=null&&tmp.level<1)
            {
                if(Input.GetKeyDown(KeyCode.Space)){
                    tmp.level=1;
                    tmp.setImg(Soil.levelImg[1]);
                    working.Add(tmp);
                }
            }
            else if(clickObject.click.name=="BoxUI03"&&clickObject.click!=null){
                if(Input.GetKeyDown(KeyCode.Space)){
                    collision.gameObject.GetComponent<Animator>().SetTrigger("isStarting");
                }
            }
        }catch(NullReferenceException ex){
            ;
        }catch(UnassignedReferenceException ex){
            ;
        }catch(MissingReferenceException ex){
            ;
        }
        
    }
}

