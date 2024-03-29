using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class BarUIController : MonoBehaviour
{
    [SerializeField]
    GameObject boat;
    [SerializeField]
    float speed;
    /*boat bar 스피드 조절을 위함.*/

    Text textScore;
    [SerializeField]
    GameObject MovingBar;
    private GraphicRaycaster GRaycast;
    PointerEventData PED;
    EventSystem eventSystem;
    int count=0;
    Vector2 InitPosition;
    Vector2 InitPosition_text;
    bool isMoving;
    void Start(){
        isMoving=false;
        textScore=GameObject.Find("Canvas").transform.GetChild(2).GetComponent<Text>();
        boat=GameObject.Find("Boat");
        MovingBar=GameObject.Find("MoveBar");
        GRaycast = GameObject.Find("Canvas").GetComponent<GraphicRaycaster>();
        eventSystem=GetComponent<EventSystem>();
        //UI내에 있는 GraphicRaycaster사용. Canvas에 보면 달려있음.

        InitPosition=new Vector2(MovingBar.GetComponent<RectTransform>().anchoredPosition.x,MovingBar.GetComponent<RectTransform>().anchoredPosition.y);
        InitPosition_text=new Vector2(textScore.GetComponent<RectTransform>().anchoredPosition.x,textScore.GetComponent<RectTransform>().anchoredPosition.y);
    }

    void OnEnable(){
        try{
            MovingBar.GetComponent<RectTransform>().anchoredPosition=InitPosition;
            count=0;
        }catch(NullReferenceException e){
            ;
        }catch(UnassignedReferenceException){
            ;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Net_Action.isThrowing){
            PED=new PointerEventData(eventSystem);
            PED.position=MovingBar.transform.position;
            List<RaycastResult> results = new List<RaycastResult>();
            GRaycast.Raycast(PED, results);
            /*canvas의 moveBar을 기준으로, raycast를 쏘아 몇개 있는지 확인한다. 자기자신을 뜻하면 1개, SpacebarUI위에 존재해야하기떄문에 실제 갯수는 2개 여야함
            results의 보관 갯수가 3개가 된다면 spacebar누를시 성공, 연타 성공 3번일때 그물을 회수할 수 있음.*/
            //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
            
            if(results.Count<=2){
                speed=-speed;
            }

            if(Input.GetKeyDown(KeyCode.Space)&&results.Count>3){
                count++;
                textScore.gameObject.SetActive(true);
                if(count>=3)
                    textScore.text="성공!";
                else
                    textScore.text="+ "+count.ToString();   
            }

            if(textScore.gameObject.activeSelf){
                textScore.gameObject.transform.Translate(UnityEngine.Random.Range(-1f,1f),UnityEngine.Random.Range(0.5f,1f),0.0f);
                Invoke("DisappearText",0.5f);
            }

            this.transform.position = Camera.main.WorldToScreenPoint(boat.transform.position+new Vector3(0,1.8f,0));
            MovingBar.transform.Translate(speed,0.0f,0.0f);

            if(count>=3){
                Net_Action.isThrowing=false;
                Debug.Log("성공!");
                this.gameObject.SetActive(false);
            }
            
        }
    }
    void DisappearText(){
        textScore.gameObject.SetActive(false);
        textScore.GetComponent<RectTransform>().anchoredPosition=InitPosition_text;
    }

/*
    private IEnumerator Moving(){
        while(true){
            if(this.transform.localPosition.x>BarPosition.x||this.transform.localPosition.x<BarPosition.x){

            }
        }
    }
    */
}
