using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeartController : MonoBehaviour
{
    [SerializeField]
    string GoTo;
    [SerializeField]
    Vector3 teleportPosition = new Vector3(0, 0, 0);
    GameManager gameManager;
    public Transform Heart;
    public int liftCount=3;
    GameObject[] trashs;
    bool isFirst;
    void Start(){
        isFirst=false;
        Heart=this.gameObject.GetComponentInChildren<Transform>();
        trashs=GameObject.FindGameObjectsWithTag("Trashs");
    }

    void Update(){
        GlobalTimer.timer+=Time.deltaTime;
        if(liftCount<3&&liftCount>=0){
            Heart.GetChild(liftCount).gameObject.SetActive(false);
        }

        if(liftCount<0){
            if(!isFirst){
                TotalGoldController.TotalGold+=Dragable.gold;
                isFirst=true;
            }
            SceneTransition();
        }

        bool isCheck=false;

        foreach(GameObject t in trashs){
            if(t.activeSelf){
                isCheck=true;
            }
        }

        if(!isCheck){
            SceneTransition();
        }

    }
        //목숨을 다할 경우 -> 씬이동
    public void SceneTransition()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        gameManager.setTransfer(GoTo);
        StartCoroutine(gameManager.FadeOut(teleportPosition));
    }
}
