using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FactoryController : MonoBehaviour,IDropHandler
{
    GameObject[] factorys;
    public static int SuccessCount = 0;
    private void Start()
    {
        SuccessCount = 0;
        factorys = GameObject.FindGameObjectsWithTag("Factory");
    }

        public void OnDrop(PointerEventData eventData)
     {
        Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
        if (factorys != null)
        {
            foreach (GameObject factory in factorys)
            {
                if (!DragAndDropController.isCollider&& eventData.pointerCurrentRaycast.gameObject.name==factory.name&&factory.GetComponent<FactoryState>().isStarting)
                    if (eventData.pointerDrag != null)
                    {
                        SuccessCount++;
                        factory.GetComponent<FactoryState>().isStoping = true;
                        DragAndDropController.isCollider = true;
                        eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                        this.gameObject.GetComponent<Image>().raycastTarget = false;
                    }
            }
        }
    }

}
