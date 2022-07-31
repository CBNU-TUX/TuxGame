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
    
    void OnCollisionEnter2D(Collision2D collision){
        try{
            SoilInfo tmp=collision.gameObject.GetComponent<SoilInfo>();
            if(clickObject.click.name=="BoxUI01"&&clickObject.click!=null&&tmp.level<1)
            {
                if(Input.GetKeyDown(KeyCode.Space)){
                    Debug.Log(collision.gameObject.name);
                    tmp.level=1;
                    tmp.setImg(Soil.levelImg[1]);
                    working.Add(tmp);
                }
            }
            else if(clickObject.click.name=="BoxUI03"&&clickObject.click!=null){
                if(Input.GetKeyDown(KeyCode.Space)){
                    collision.gameObject.GetComponent<Animator>().SetTrigger("isStarting");
                }
            }else if(clickObject.click.name=="BoxUI04"&&clickObject.click!=null&&tmp.level>=1){
                if(Input.GetKeyDown(KeyCode.Space)){
                    Debug.Log(collision.gameObject.name);
                    tmp.treelevel="seed";
                    GameObject child=collision.gameObject.transform.Find("seed").gameObject;
                    Debug.Log(child.name);
                    child.gameObject.SetActive(true);
                }
            }else if(clickObject.click.name=="BoxUI05"&&clickObject.click!=null&&tmp.level>=1){
                if(Input.GetKeyDown(KeyCode.Space)){
                    Debug.Log(collision.gameObject.name);
                    tmp.treelevel="sprout";
                    GameObject child=collision.gameObject.transform.Find("sprout").gameObject;
                    Debug.Log(child.name);
                    child.gameObject.SetActive(true);
                }
            }else if(clickObject.click.name=="BoxUI06"&&clickObject.click!=null&&tmp.level>=1){
                if(Input.GetKeyDown(KeyCode.Space)){
                    Debug.Log(collision.gameObject.name);
                    tmp.treelevel="tree";
                    GameObject child=collision.gameObject.transform.Find("tree").gameObject;
                    Debug.Log(child.name);
                    child.gameObject.SetActive(true);
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

    void OnTriggerStay2D(Collider2D collision){
        try{
            SoilInfo tmp=collision.gameObject.GetComponent<SoilInfo>();
            if(clickObject.click.name=="BoxUI01"&&clickObject.click!=null&&tmp.level<1)
            {
                if(Input.GetKeyDown(KeyCode.Space)){
                    Debug.Log(collision.gameObject.name);
                    tmp.level=1;
                    tmp.setImg(Soil.levelImg[1]);
                    working.Add(tmp);
                }
            }
            else if(clickObject.click.name=="BoxUI03"&&clickObject.click!=null){
                if(Input.GetKeyDown(KeyCode.Space)){
                    collision.gameObject.GetComponent<Animator>().SetTrigger("isStarting");
                }
            }else if(clickObject.click.name=="BoxUI04"&&clickObject.click!=null&&tmp.level>=1){
                if(Input.GetKeyDown(KeyCode.Space)){
                    Debug.Log(collision.gameObject.name);
                    tmp.treelevel="seed";
                    GameObject child=collision.gameObject.transform.Find("seed").gameObject;
                    Debug.Log(child.name);
                    child.gameObject.SetActive(true);
                }
            }else if(clickObject.click.name=="BoxUI05"&&clickObject.click!=null&&tmp.level>=1){
                if(Input.GetKeyDown(KeyCode.Space)){
                    Debug.Log(collision.gameObject.name);
                    tmp.treelevel="sprout";
                    GameObject child=collision.gameObject.transform.Find("sprout").gameObject;
                    Debug.Log(child.name);
                    child.gameObject.SetActive(true);
                }
            }else if(clickObject.click.name=="BoxUI06"&&clickObject.click!=null&&tmp.level>=1){
                if(Input.GetKeyDown(KeyCode.Space)){
                    Debug.Log(collision.gameObject.name);
                    tmp.treelevel="tree";
                    GameObject child=collision.gameObject.transform.Find("tree").gameObject;
                    Debug.Log(child.name);
                    child.gameObject.SetActive(true);
                }
            }
        }catch(NullReferenceException ex){
            ;
        }catch(UnassignedReferenceException ex){
            ;
        }catch(MissingReferenceException e){
            ;
        }
    }
}

