using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEditor;

public class DragAndDropController : MonoBehaviour, IDragHandler,IPointerDownHandler, IBeginDragHandler,IEndDragHandler,IDropHandler
{
    //SerializeField�� ��� private ������ inspector���� �ǵ帱 �� �ֵ��� �ϴ� ����Ƽ ���� ����
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
        //canvasGroup�� �ش��ϴ� ��� ĵ������ �ٰ��� �����ϱ� ���ؼ� ���.
        //billTransform�� anchoredPosition�� ������. anchoredPosition�� ����� ����, inspector�� x,y��ǥ ����� ����.
    }
    //drag�� �����Ҷ�
    public void OnBeginDrag(PointerEventData eventData)
    {
        //�����Ҷ� raycast�� ��.
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        Debug.Log("OnBeginDrag");
    }

    public void OnDrag(PointerEventData eventData)
    {

        billTransform.anchoredPosition += eventData.delta/gameCanvas.scaleFactor;
        Debug.Log("OnDrag");
    }

    //drag�� ��������
    public void OnEndDrag(PointerEventData eventData)
    {
        
        if (!isCollider)
        {
            canvasGroup.blocksRaycasts = true;
            billTransform.anchoredPosition = loadedPostion;
            Debug.Log("case1");
        }
        else
        {
            SoundManager.instance.platSE("win");
        }
        isCollider = false;
        canvasGroup.alpha = 1f;
        Debug.Log("EndDrag");
        //canvasGroup.blocksRaycasts = true;
        //drag�� �������� raycast ��
    }
    //drag�� ���� Ŭ���Ҷ�
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop1");
    }
}
