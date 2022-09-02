
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
public class ClickController : MonoBehaviour
{

    Button []buttons;
    bool isCheck=false;
    public GameObject click;


    void Start(){
        buttons = GetComponentsInChildren<Button>();
    }

    public void OnClick(){
        GameObject child;
        if(TotalGoldController.TotalGold>0){
            if(!isCheck&&!Input.GetKeyDown(KeyCode.Space)){
                click = EventSystem.current.currentSelectedGameObject;
                child=click.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject;
                if(PlayerWorking.shovel==1||PlayerWorking.wateringCan==1){
                    RectTransform clickTransform=click.GetComponent<RectTransform>();
                    clickTransform.anchoredPosition=new Vector2(clickTransform.anchoredPosition.x,clickTransform.anchoredPosition.y+30);
                    isCheck=true;
                    foreach(Button button in buttons){
                        if(click.name!=button.name){
                            button.interactable = false;
                        }
                    }
                }else if(PlayerWorking.fertillzer>0){
                    RectTransform clickTransform=click.GetComponent<RectTransform>();
                    clickTransform.anchoredPosition=new Vector2(clickTransform.anchoredPosition.x,clickTransform.anchoredPosition.y+30);
                    isCheck=true;
                    foreach(Button button in buttons){
                        if(click.name!=button.name){
                            button.interactable = false;
                        }
                    }
                }else if(PlayerWorking.seed>0){
                    
                    RectTransform clickTransform=click.GetComponent<RectTransform>();
                    clickTransform.anchoredPosition=new Vector2(clickTransform.anchoredPosition.x,clickTransform.anchoredPosition.y+30);
                    isCheck=true;
                    foreach(Button button in buttons){
                        if(click.name!=button.name){
                            button.interactable = false;
                        }
                    }
                }else if(PlayerWorking.sprout>0){
                    RectTransform clickTransform=click.GetComponent<RectTransform>();
                    clickTransform.anchoredPosition=new Vector2(clickTransform.anchoredPosition.x,clickTransform.anchoredPosition.y+30);
                    isCheck=true;
                    foreach(Button button in buttons){
                        if(click.name!=button.name){
                            button.interactable = false;
                        }
                    }
                }else if(PlayerWorking.sapling>0){

                    RectTransform clickTransform=click.GetComponent<RectTransform>();
                    clickTransform.anchoredPosition=new Vector2(clickTransform.anchoredPosition.x,clickTransform.anchoredPosition.y+30);
                    isCheck=true;
                    foreach(Button button in buttons){
                        if(click.name!=button.name){
                            button.interactable = false;
                        }
                    }
                }

            }else if(isCheck&&!Input.GetKeyDown(KeyCode.Space)){
                click = EventSystem.current.currentSelectedGameObject;
                RectTransform clickTransform=click.GetComponent<RectTransform>();
                clickTransform.anchoredPosition=new Vector2(clickTransform.anchoredPosition.x,clickTransform.anchoredPosition.y-30);
                isCheck=false;
                foreach(Button button in buttons){
                    if(click.name!=button.name){
                        button.interactable = true;
                    }
                }
            }
        }
    }
    public void Buy(){
        
        bool isFirst=false;
        click = EventSystem.current.currentSelectedGameObject;
        GameObject child;
        switch(click.name){
            case "1":
                child=GameObject.Find("BoxUI01").transform.GetChild(1).gameObject.transform.GetChild(0).gameObject;
                break;
            case "2":
                child=GameObject.Find("BoxUI02").transform.GetChild(1).gameObject.transform.GetChild(0).gameObject;
                break;
            case "3":
                child=GameObject.Find("BoxUI03").transform.GetChild(1).gameObject.transform.GetChild(0).gameObject;
                break;
            case "4":
                child=GameObject.Find("BoxUI04").transform.GetChild(1).gameObject.transform.GetChild(0).gameObject;
                break;
            case "5":
                child=GameObject.Find("BoxUI05").transform.GetChild(1).gameObject.transform.GetChild(0).gameObject;
                break;
            default:
                child=GameObject.Find("BoxUI06").transform.GetChild(1).gameObject.transform.GetChild(0).gameObject;
                break;

        }
        
        try{
            if(!isFirst){

                string price=click.transform.GetChild(0).gameObject.GetComponent<Text>().text;
                Debug.Log(click.name+" "+price);
                if(TotalGoldController.TotalGold>0){

                    if(price.Contains("50")){
                            
                        TotalGoldController.TotalGold-=50;
                        if(TotalGoldController.TotalGold<0){
                            TotalGoldController.TotalGold+=50;
                            return ;
                        }
                        if(click.name=="1"){
                            PlayerWorking.shovel=1;
                            child.GetComponent<Text>().text=PlayerWorking.shovel.ToString()+" 개";
                        }else if(click.name=="3"){
                            PlayerWorking.wateringCan=1;
                            child.GetComponent<Text>().text=PlayerWorking.wateringCan.ToString()+" 개";
                        }else if(click.name=="4"){
                            PlayerWorking.seed+=1;
                            child.GetComponent<Text>().text=PlayerWorking.seed.ToString()+" 개";
                        }

                    }else if(price.Contains("100")){

                        TotalGoldController.TotalGold-=100;
                        
                        if(TotalGoldController.TotalGold<0){
                            TotalGoldController.TotalGold+=100;
                            return;
                        }

                        if(click.name=="2"){                           
                            PlayerWorking.fertillzer+=1;
                            child.GetComponent<Text>().text=PlayerWorking.fertillzer.ToString()+" 개";
                        }else{
                            PlayerWorking.sprout+=1;
                            child.GetComponent<Text>().text=PlayerWorking.sprout.ToString()+" 개";
                        }
                    

                    }else if(price.Contains("300")){
                        PlayerWorking.sapling+=1;
                        TotalGoldController.TotalGold-=300;
                        
                        if(TotalGoldController.TotalGold<0){
                            TotalGoldController.TotalGold+=300;
                            PlayerWorking.sapling-=1;
                        }
                        child.GetComponent<Text>().text=PlayerWorking.sapling.ToString()+" 개";
                    }
                }
                isFirst=true;
            }
        }catch(NullReferenceException ex){
            ;
        }
        
    }
    // Start is called before the first frame update
   
}
