using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEditor;
using UnityEditor.UIElements;

public class DragAndDropController : MonoBehaviour, IDragHandler,IPointerDownHandler, IBeginDragHandler,IEndDragHandler,IDropHandler
{
    //SerializeField의 경우 private 변수를 inspector에서 건드릴 수 있도록 하는 유니티 제공 도구
    [SerializeField] private Canvas gameCanvas;
    private RectTransform billTransform;
    private CanvasGroup canvasGroup;
    private Vector3 loadedPostion;
    public static bool isCollider = false;
    GameObject[] factorys;
    private void Awake()
    {
        billTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        loadedPostion = billTransform.anchoredPosition;
        factorys = GameObject.FindGameObjectsWithTag("Factory");
        //canvasGroup에 해당하는 모든 캔버스를 다같이 조절하기 위해서 사용.
        //billTransform의 anchoredPosition을 가져옴. anchoredPosition을 사용한 이유, inspector상 x,y좌표 사용을 위함.
    }
    //drag를 시작할때
    public void OnBeginDrag(PointerEventData eventData)
    {
        //시작할때 raycast를 끔.
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        Debug.Log("OnBeginDrag");
    }

    public void OnDrag(PointerEventData eventData)
    {

        billTransform.anchoredPosition += eventData.delta/gameCanvas.scaleFactor;
        Debug.Log("OnDrag");
    }

    //drag가 끝났을때
    public void OnEndDrag(PointerEventData eventData)
    {
        
        if (!isCollider)
        {
            canvasGroup.blocksRaycasts = true;
            billTransform.anchoredPosition = loadedPostion;
            Debug.Log("case1");
        }
        isCollider = false;
        canvasGroup.alpha = 1f;
        Debug.Log("EndDrag");
        //canvasGroup.blocksRaycasts = true;
        //drag가 끝났을때 raycast 함
    }
    //drag를 위해 클릭할때
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop1");
    }
}
