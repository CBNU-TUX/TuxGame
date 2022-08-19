using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    GameObject[] TrashBoxs;
    Animator Ani;
    //[SerializeField]
    //private Transform parentTransform;
    //[SerializeField]
    //private GameObject hudTextPrefab;
    public static bool is_ground = true;
    public static bool is_Right = false;


    void Start() 
    {
        TrashBoxs = GameObject.FindGameObjectsWithTag("TrashBox");
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        try {
            foreach (GameObject TrashBox in TrashBoxs) {
                RectTransform image = TrashBox.GetComponentInChildren<RectTransform>();

                if (eventData.pointerCurrentRaycast.gameObject.name == image.GetChild(0).name && eventData.pointerDrag.GetComponent<TrashInfo>().getType() == image.name) {
                    Money.is_first = true;
                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = image.anchoredPosition;
                    eventData.pointerDrag.GetComponent<RectTransform>().gameObject.SetActive(false);
                    RandomSpawn.spawn = true;
                    is_Right = true;
                    is_ground = false;
                }
                else if (eventData.pointerCurrentRaycast.gameObject.name == image.GetChild(0).name && eventData.pointerDrag.GetComponent<TrashInfo>().getType() != image.name)
                {
                    //원래 위치로 되돌아가야함.
                    Money.is_first = false;
                    is_Right = false;
                    is_ground = false;
                }
            }
            CloseDoor();
        } catch (NullReferenceException e) {
            is_ground = true;
        }
    }
    void CloseDoor()
    {
        try
        {
            foreach(GameObject trash in TrashBoxs){
                 trash.GetComponent<Animator>().SetBool("isIdle", true);
                trash.GetComponent<Animator>().SetBool("isOpening", true);
            }
        }
        catch (NullReferenceException e)
        {
            Debug.Log("Animator is null");
        }
    }

}
