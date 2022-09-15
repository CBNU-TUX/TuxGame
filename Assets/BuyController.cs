
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class BuyController : MonoBehaviour
{
    public GameObject click;
    public void Buy(){

        try{

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
        
                if(!isFirst){

                    string price=click.transform.GetChild(0).gameObject.GetComponent<Text>().text;
                    Debug.Log(click.name+" "+price);
                    if(TotalGoldController.TotalGold>0){

                        if(price.Contains("250")){
                    
                            if(click.name=="1"){
                                if(PlayerWorking.shovel<1){
                                    TotalGoldController.TotalGold-=250;
                                    if(TotalGoldController.TotalGold<0){
                                        TotalGoldController.TotalGold+=250;
                                    return ;
                                    }
                                }   
                                PlayerWorking.shovel=1;
                                child.GetComponent<Text>().text=PlayerWorking.shovel.ToString()+" 개";
                            }else if(click.name=="3"){
                                if(PlayerWorking.wateringCan<1){
                                    TotalGoldController.TotalGold-=250;
                                    if(TotalGoldController.TotalGold<0){
                                        TotalGoldController.TotalGold+=250;
                                    return ;
                                    }
                                }   
                                PlayerWorking.wateringCan=1;
                                child.GetComponent<Text>().text=PlayerWorking.wateringCan.ToString()+" 개";
                            }else if(click.name=="4"){
                                TotalGoldController.TotalGold-=250;
                                    if(TotalGoldController.TotalGold<0){
                                        TotalGoldController.TotalGold+=250;
                                        return ;
                                    }
                                PlayerWorking.seed+=1;
                                child.GetComponent<Text>().text=PlayerWorking.seed.ToString()+" 개";
                            }

                        }else if(price.Contains("500")){

                            TotalGoldController.TotalGold-=500;
                            
                            if(TotalGoldController.TotalGold<0){
                                TotalGoldController.TotalGold+=500;
                                return;
                            }

                            if(click.name=="2"){                           
                                PlayerWorking.fertillzer+=1;
                                child.GetComponent<Text>().text=PlayerWorking.fertillzer.ToString()+" 개";
                            }else{
                                PlayerWorking.sprout+=1;
                                child.GetComponent<Text>().text=PlayerWorking.sprout.ToString()+" 개";
                            }
                        

                        }else if(price.Contains("1000")){
                            PlayerWorking.sapling+=1;
                            TotalGoldController.TotalGold-=1000;
                            
                            if(TotalGoldController.TotalGold<0){
                                TotalGoldController.TotalGold+=1000;
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
}
