
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
    
    // Start is called before the first frame update
   
}
