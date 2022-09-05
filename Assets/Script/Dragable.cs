using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Dragable : MonoBehaviour,IBeginDragHandler,IEndDragHandler,IDragHandler,IPointerDownHandler
{
    static public int gold = 300;
    Color color;
    String text;
    GameObject[] TrashBoxs;

    [SerializeField] private Canvas canvas;
    
    public static bool is_Close=false;
    public RectTransform rectTransform;
    private Vector3 loadedPosition;
    private CanvasGroup canvasGroup;
    public Text won;
    Animator ani;
    Animator anima;
    
    void Start()
    {
        TrashBoxs = GameObject.FindGameObjectsWithTag("TrashBox");
    }
    private void Awake()
    {
        won.text = gold.ToString();
        rectTransform = GetComponent<RectTransform>();
        loadedPosition = rectTransform.anchoredPosition;
        canvasGroup = GetComponent<CanvasGroup>();
    }
    void Update()
    {
        won.text = gold.ToString();
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
                Debug.Log("case1");
            }else{
                CloseDoor();
                Debug.Log("case2");
            }
        }
        catch(NullReferenceException ex)
        {
            Invoke("CloseDoor",0.2f);
            Debug.Log("case3");
            Debug.Log("gameobject is null");
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

    public void OnEndDrag(PointerEventData eventData)
    {
        //foreach (GameObject TrashBox in TrashBoxs)
        //{
        //    anima=TrashBox.GetComponentInParent<Animator>();
        //    anima.SetBool("isIdle", true);
        //    anima.SetBool("isOpening", false);
        //}
        if (!Slot.is_Right)
        {
            canvasGroup.blocksRaycasts = true;
            rectTransform.anchoredPosition = loadedPosition;
            if (!Slot.is_ground)
            {
                color = Color.red;
                text = "Wrong";
                Slot.is_ground = true;
                CloseDoor();
                //SpawnHUDText(text, color);
            }
        }
        else
        {
            RandomSpawn.spawn = true;
            color = Color.blue;
            text = "Correct";
            CloseDoor();
            //SpawnHUDText(text,color);
        }
        
        Slot.is_Right= false;
        canvasGroup.alpha = 1f;
        is_Close = true;
        won.text = gold.ToString();
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
        CloseDoor();
        Debug.Log("pointerdown");
    }

}
