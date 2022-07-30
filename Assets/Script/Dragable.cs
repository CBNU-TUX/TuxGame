using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Dragable : MonoBehaviour,IBeginDragHandler,IEndDragHandler,IDragHandler,IPointerDownHandler
{
    int gold = 1000;
    Color color;
    String text;
    [SerializeField] private Canvas canvas;
    //[SerializeField]
    //private Transform parentTransform;
    //[SerializeField]
    //private GameObject hudTextPrefab;
    public static bool is_Close=false;
    public static RectTransform rectTransform;
    private Vector3 loadedPosition;
    private CanvasGroup canvasGroup;
    public Text won;
    Animator ani;
    private void Awake()
    {
        won.text = gold.ToString();
        rectTransform = GetComponent<RectTransform>();
        loadedPosition = rectTransform.anchoredPosition;
        canvasGroup = GetComponent<CanvasGroup>();
    }
    // Start is called before the first frame update

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        
        try
        {
            ani=eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Animator>();
            if(eventData.pointerCurrentRaycast.gameObject.tag=="Image"&&eventData.pointerCurrentRaycast.gameObject!=null)
            {
                ani.SetBool("isIdle",false);
                ani.SetBool("isOpening",false);
            }else{
                ani.SetBool("isIdle",false);
                ani.SetBool("isOpening",true);
                Invoke("CloseDoor",0.2f);
            }
        }
        catch(NullReferenceException ex)
        {
            Invoke("CloseDoor",0.2f);
            Debug.Log("gameobject is null");
        }
    }

    void CloseDoor(){
        try{
            ani.SetBool("isIdle",true);
            ani.SetBool("isOpening",false);
        }catch(NullReferenceException e){
            Debug.Log("Animator is null");
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!Slot.is_Right)
        {
            canvasGroup.blocksRaycasts = true;
            rectTransform.anchoredPosition = loadedPosition;
            if (!Slot.is_ground)
            {
                color = Color.red;
                text = "Wrong";
                gold -= 10;
                won.text = gold.ToString();
                Slot.is_ground = true;
                //SpawnHUDText(text, color);
            }
        }
        else
        {
            color = Color.blue;
            text = "Correct";
            //SpawnHUDText(text,color);
        }
           
        Slot.is_Right= false;
        canvasGroup.alpha = 1f;
        is_Close = true;
        Debug.Log("EndDrag");
    }

    //public void SpawnHUDText(string text,Color color)
    //{
    //    GameObject clone = Instantiate(hudTextPrefab);
    //    clone.transform.SetParent(parentTransform);
    //    clone.GetComponent<Trash_text>.Play(text,color);
    //    Debug.Log(text);
    //}
    public void OnPointerDown(PointerEventData eventData)
    { 
        Debug.Log("pointerdown");
    }
}
