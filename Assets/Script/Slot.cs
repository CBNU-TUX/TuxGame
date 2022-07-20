using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    GameObject[] TrashBoxs;
    public static bool is_Right = false;
    
    void Start(){
        TrashBoxs=GameObject.FindGameObjectsWithTag("TrashBox");
    }

    public void OnDrop(PointerEventData eventData)
    {
        try{
            foreach(GameObject TrashBox in TrashBoxs){
                RectTransform image=TrashBox.GetComponentInChildren<RectTransform>();

                if(eventData.pointerCurrentRaycast.gameObject.name==image.GetChild(0).name&&eventData.pointerDrag.GetComponent<TrashInfo>().getType()==image.name){
                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = image.anchoredPosition;
                    eventData.pointerDrag.GetComponent<RectTransform>().gameObject.SetActive(false);
                }else{
                    //원래 위치로 되돌아가야함.
                    is_Right = false;
                }
            }
        }catch(NullReferenceException e){
            is_Right = false;
        }
    }
}
