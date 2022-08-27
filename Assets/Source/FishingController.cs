using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FishingController : MonoBehaviour
{
    static public bool isFishing=false;
    Text Money;
    static int gold = 0;
    GameObject[] trash;
    GameManager gameManager;
    [SerializeField]
    string GoTo;
    [SerializeField]
    Vector3 teleportPosition = new Vector3(0, 0, 0);

    bool isFirst;
    void Start(){
        isFirst=false;
        Money=GameObject.Find("don").GetComponent<Text>();
        Money.text = gold.ToString();    
        trash=GameObject.FindGameObjectsWithTag("Trashs");
    }

    private void OnTriggerStay2D(Collider2D collision) //Net�� ������� �浹�������
    {
     if (collision.gameObject.tag=="Trashs" && isFishing)
        {
            Debug.Log("이거 왜 안될까");
            gold += 50; //오브젝트마다 다르게할 예정.
            Money.text=gold.ToString();
            collision.gameObject.SetActive(false);
            Invoke("Endfihsing", 0.3f);
        }
    }

    void Update(){
        
        bool isCheck=false;

        foreach(GameObject t in trash){
            if(t.activeSelf){
                isCheck=true;
            }
        }

        if(!isCheck){
            if(!isFirst){
                isFirst=true;
                TotalGoldController.TotalGold+=gold;
            }
            SceneTransition();
        }

    }

    void Endfihsing()
    {
        FishingController.isFishing=false;
    }

    public void SceneTransition()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        gameManager.setTransfer(GoTo);
        //StartCoroutine(gameManager.FadeOut(teleportPosition));
    }
}
