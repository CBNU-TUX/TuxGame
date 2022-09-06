using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class PlayerWorking : MonoBehaviour
{
    static public List<SoilInfo> working;
   
    static public int shovel;
    static public int fertillzer;
    static public int wateringCan;
    static public int seed;
    static public int sprout;
    static public int sapling;

    [SerializeField]
    GameObject[] textField;
    [SerializeField]
    GameObject Slider;

    static public int treeCount;
    // Start is called before the first frame update
    ClickController clickObject;
    void Start(){
        working=new List<SoilInfo>();
        clickObject = GameObject.FindObjectOfType<ClickController>();
        textField=GameObject.FindGameObjectsWithTag("Text");
        Slider=GameObject.FindGameObjectWithTag("SuccessSlider");
    }

    void Update(){
        textField=GameObject.FindGameObjectsWithTag("Text");
        Slider=GameObject.FindGameObjectWithTag("SuccessSlider");
        try{
            
            foreach(GameObject text in textField){
                switch (text.name)
                {
                    case "shovel": 
                        text.GetComponent<Text>().text=shovel.ToString()+" 개"; //삽
                        break;
                    case "fertillzer":
                        text.GetComponent<Text>().text=fertillzer.ToString()+" 개"; //비료
                        break;
                    case "wateringcan":
                        text.GetComponent<Text>().text=wateringCan.ToString()+" 개"; //물
                        break;
                    case "seed":
                        text.GetComponent<Text>().text=seed.ToString()+" 개";
                        break;
                    case "sprout":
                        text.GetComponent<Text>().text=sprout.ToString()+" 개";
                        break;
                    default:
                        text.GetComponent<Text>().text=sapling.ToString()+" 개";
                        break;
                }
            }
            
            Slider.GetComponent<Slider>().value=(100f/16f)*treeCount;
        }catch(NullReferenceException e){

        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        
        try{
            if(clickObject==null)
                clickObject = GameObject.FindObjectOfType<ClickController>();
            GameObject Tchild=clickObject.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject;
            SoilInfo tmp=collision.gameObject.GetComponent<SoilInfo>();
            if(clickObject.click.name=="BoxUI01"&&clickObject.click!=null&&tmp.level<1&&shovel>0)
            {
                if(Input.GetKey(KeyCode.Space))
                {
                    PlayerMovement.canMove = false;
                    SoundManager.instance.platSE("shovel");
                    Invoke("Moveable", 1f);
                    tmp.treelevel="No";
                    tmp.level=1;
                    tmp.setImg(Soil.levelImg[1]);
                    working.Add(tmp);
                    this.gameObject.GetComponent<Animator>().SetTrigger("isDigging");
                }
            }else if(clickObject.click.name=="BoxUI02"&&clickObject.click!=null&&fertillzer>0&&tmp.level>=1){
                bool isFirst=false;
                if(Input.GetKey(KeyCode.Space)){
                    if(!isFirst){
                        Debug.Log("비료 사용"+collision.name);
                        tmp.fertillzer++;
                        fertillzer--;
                        textField[3].GetComponent<Text>().text=fertillzer.ToString()+" 개";
                    }
                }
                isFirst=true;
            }
            else if(clickObject.click.name=="BoxUI03"&&clickObject.click!=null&&wateringCan>0){
                if(Input.GetKey(KeyCode.Space)){
                    SoundManager.instance.platSE("water");
                    collision.gameObject.GetComponent<Animator>().SetTrigger("isStarting");
                    this.gameObject.GetComponent<Animator>().SetTrigger("isWater");
                }
            }else if(clickObject.click.name=="BoxUI04"&&clickObject.click!=null&&tmp.level>=1&&tmp.treelevel=="No"&&seed>0){
                if(Input.GetKey(KeyCode.Space)){
                    SoundManager.instance.platSE("sow");
                    Debug.Log("이거 되는거 맞아? "+collision.name);
                    tmp.isGrowing=true;
                    tmp.treelevel="seed";
                    tmp.days=GlobalTimer.day;
                    GameObject child=collision.gameObject.transform.Find("seed").gameObject;
                    child.gameObject.SetActive(true);
                    seed-=1;
                    textField[0].GetComponent<Text>().text=seed.ToString()+" 개";
                }
            }else if(clickObject.click.name=="BoxUI05"&&clickObject.click!=null&&tmp.level>=1&&tmp.treelevel=="No"&&sprout>0){
                if(Input.GetKey(KeyCode.Space)){
                    tmp.isGrowing=true;
                    Debug.Log(collision.gameObject.name);
                    tmp.treelevel="sprout";
                    GameObject child=collision.gameObject.transform.Find("sprout").gameObject;
                    Debug.Log(child.name);
                    child.gameObject.SetActive(true);
                    sprout-=1;
                    tmp.days=GlobalTimer.day;
                    textField[1].GetComponent<Text>().text=PlayerWorking.sprout.ToString()+" 개";
                }
            }else if(clickObject.click.name=="BoxUI06"&&clickObject.click!=null&&tmp.level>=1&&tmp.treelevel=="No"&&sapling>0){
                if(Input.GetKey(KeyCode.Space)){
                    sapling-=1;
                    textField[2].GetComponent<Text>().text=PlayerWorking.sapling.ToString()+" 개";
                    Debug.Log(collision.gameObject.name);
                    tmp.treelevel="tree";
                    tmp.isGrowing=true;
                    GameObject child=collision.gameObject.transform.Find("tree").gameObject;
                    Debug.Log(child.name);
                    tmp.days=GlobalTimer.day;
                    child.gameObject.SetActive(true);
                }
            }

        }catch(NullReferenceException ex){
            ;
        }catch(UnassignedReferenceException ex){
            ;
        }catch(MissingReferenceException e){
            ;
        }catch(IndexOutOfRangeException e){
            ;
        }
    }
    void Moveable()
    {
        SoundManager.instance.platSE("shovel");
        PlayerMovement.canMove = true;
    }
}

