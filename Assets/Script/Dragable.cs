using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Dragable : MonoBehaviour,IBeginDragHandler,IEndDragHandler,IDragHandler,IPointerDownHandler
{
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    Animator ani;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
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
        
        try{
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
        }catch(NullReferenceException ex){
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
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

    }

    public void OnPointerDown(PointerEventData eventData)
    { 
        ;
    }
}
