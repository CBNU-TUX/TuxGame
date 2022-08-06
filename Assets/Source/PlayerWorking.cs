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
            if(clickObject==null)
                clickObject = GameObject.FindObjectOfType<ClickController>();
            Debug.Log("1");
            SoilInfo tmp=collision.gameObject.GetComponent<SoilInfo>();
            if(clickObject.click.name=="BoxUI01"&&clickObject.click!=null&&tmp.level<1)
            {
                Debug.Log("2");
                if(Input.GetKey(KeyCode.Space)){
                    tmp.treelevel="No";
                    Debug.Log("3");
                    tmp.level=1;
                    tmp.setImg(Soil.levelImg[1]);
                    working.Add(tmp);
                }
            }
            else if(clickObject.click.name=="BoxUI03"&&clickObject.click!=null){
                if(Input.GetKey(KeyCode.Space)){
                    collision.gameObject.GetComponent<Animator>().SetTrigger("isStarting");
                }
            }else if(clickObject.click.name=="BoxUI04"&&clickObject.click!=null&&tmp.level>=1&&tmp.treelevel=="No"){
                if(Input.GetKey(KeyCode.Space)){
                    tmp.isGrowing=true;
                    Debug.Log(collision.gameObject.name);
                    tmp.treelevel="seed";
                    GameObject child=collision.gameObject.transform.Find("seed").gameObject;
                    Debug.Log(child.name);
                    child.gameObject.SetActive(true);
                }
            }else if(clickObject.click.name=="BoxUI05"&&clickObject.click!=null&&tmp.level>=1&&tmp.treelevel=="No"){
                if(Input.GetKey(KeyCode.Space)){
                    tmp.isGrowing=true;
                    Debug.Log(collision.gameObject.name);
                    tmp.treelevel="sprout";
                    GameObject child=collision.gameObject.transform.Find("sprout").gameObject;
                    Debug.Log(child.name);
                    child.gameObject.SetActive(true);
                }
            }else if(clickObject.click.name=="BoxUI06"&&clickObject.click!=null&&tmp.level>=1&&tmp.treelevel=="No"){
                if(Input.GetKey(KeyCode.Space)){
                   
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

