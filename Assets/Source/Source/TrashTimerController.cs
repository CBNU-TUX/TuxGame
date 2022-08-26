using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TrashTimerController : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField]
    float LimitedTime;
    Text timer;
    bool isFirst;
    [Tooltip("Transfer Scene && Player Position")]
    [SerializeField]
    string GoTo;
    [SerializeField]
    Vector3 teleportPosition = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        isFirst=false;
       timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Text>();
    }

    protected void Timer(){
        GlobalTimer.timer+=Time.deltaTime;
        LimitedTime -= Time.deltaTime;
        timer.text = ((int)LimitedTime).ToString();
    }
    // Update is called once per frame
    void Update()
    {
        if (LimitedTime <= 0)
        {
            if(!isFirst){
                isFirst=true;
                TotalGoldController.TotalGold+=Dragable.gold;
            }
            
            SceneTransition();
        }
        else
        {
            Timer();
        }
    }

    public void SceneTransition()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        gameManager.setTransfer(GoTo);
        StartCoroutine(gameManager.FadeOut(teleportPosition));
    }
}
