using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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
    GameManager gameManager;    
    [SerializeField]
    GameObject[] textField;
    [SerializeField]
    GameObject Slider;
    GameObject[] soils;
    static public int treeCount;
    // Start is called before the first frame update
    ClickController clickObject;
    void Start(){
        soils= GameObject.FindGameObjectsWithTag("soil");
        working=new List<SoilInfo>();
        clickObject = GameObject.FindObjectOfType<ClickController>();
        textField=GameObject.FindGameObjectsWithTag("Text");
        Slider=GameObject.FindGameObjectWithTag("SuccessSlider");
        
    }

    void Update(){
        textField=GameObject.FindGameObjectsWithTag("Text");
        Slider=GameObject.FindGameObjectWithTag("SuccessSlider");
        soils= GameObject.FindGameObjectsWithTag("soil");
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
            
            Slider.GetComponent<Slider>().value=(100f/18f)*treeCount;

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
                    Invoke("Moveable1", 1f);
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
                        this.gameObject.GetComponent<Animator>().SetTrigger("isSpread");
                    }
                }
                isFirst=true;
            }
            else if(clickObject.click.name=="BoxUI03"&&clickObject.click!=null&&wateringCan>0){
                if(Input.GetKey(KeyCode.Space)){
                    PlayerMovement.canMove = false;
                    SoundManager.instance.platSE("water");
                    Invoke("Moveable2", 1f);
                    collision.gameObject.GetComponent<Animator>().SetTrigger("isStarting");
                    this.gameObject.GetComponent<Animator>().SetTrigger("isWater");
                }
            }else if(clickObject.click.name=="BoxUI04"&&clickObject.click!=null&&tmp.level>=1&&tmp.treelevel=="No"&&seed>0){
                if(Input.GetKey(KeyCode.Space)){
                    PlayerMovement.canMove = false;
                    SoundManager.instance.platSE("sow");
                    Invoke("Moveable3", 1f);
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
                    tmp.days=GlobalTimer.day-1;
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
                    tmp.days=GlobalTimer.day-2;
                    child.gameObject.SetActive(true);
                }
            }

            foreach(SoilInfo work in working){
                Debug.Log("work의 이름"+work.name);
                if(work.name==tmp.name){
                    Debug.Log("? tmp 이름과 현재 work의 level"+tmp.name+" "+work.level);
                    working.Add(tmp);
                    //work.treelevel=soil.GetComponent<SoilInfo>().treelevel;
                    //wor.days=soil.GetComponent<SoilInfo>().days;
                    //    t.fertillzer=soil.GetComponent<SoilInfo>().fertillzer;
                }
            }

            
            foreach(GameObject soil in soils){
                foreach(SoilInfo t in working){
                    if(t.name==soil.GetComponent<SoilInfo>().name){
                        Debug.Log("저장된 tmp"+tmp.name);
                        t.treelevel=soil.GetComponent<SoilInfo>().treelevel;
                        t.days=soil.GetComponent<SoilInfo>().days;
                        t.fertillzer=soil.GetComponent<SoilInfo>().fertillzer;
                    }
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
    void Moveable1()
    {
        SoundManager.instance.platSE("shovel");
        PlayerMovement.canMove = true;
    }
    void Moveable2()
    {
        SoundManager.instance.platSE("water");
        PlayerMovement.canMove = true;
    }
    void Moveable3()
    {
        SoundManager.instance.platSE("sow");
        PlayerMovement.canMove = true;
    }
    public void SceneTransition()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        gameManager.setTransfer("Ending");
        gameManager.ChangeScene("Ending",new Vector3(0,0,0));
        GameObject.Find("Player").GetComponent<Animator>().SetBool("isTreeZone",false);
    }

     void OnEnable()
    {
    	  // 씬 매니저의 sceneLoaded에 체인을 건다.
        SceneManager.sceneLoaded += OnSceneLoaded;
        treeCount=0;
        try{
            foreach(SoilInfo tmp in working){
                if(tmp.treelevel=="tree1"){
                    treeCount++;
                    Debug.Log("씬 등장시 treeCount 확인하기");
                }
            }
            
            Slider.GetComponent<Slider>().value=(100f/18f)*treeCount;
            
        }catch(NullReferenceException){

        }
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode){

        treeCount=0;
        try{
            foreach(SoilInfo tmp in working){
                if(tmp.treelevel=="tree1"){
                    treeCount++;
                    Debug.Log("씬 등장시 treeCount 확인하기");
                }
            }
            
            Slider.GetComponent<Slider>().value=(100f/18f)*treeCount;
            
        }catch(NullReferenceException){

        }
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    
    }
}

