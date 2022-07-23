using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    public static bool isEnding=false;
    [SerializeField]
    float LimitedTime;
    Text timer;
    [SerializeField]
    Text Result;

    // Start is called before the first frame update
    void Start()
    {
       isEnding = false;
       timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Text>();
    }

    protected void Timer(){
        LimitedTime -= Time.deltaTime;
        timer.text = ((int)LimitedTime).ToString();
    }
    // Update is called once per frame
    void Update()
    {
        if (LimitedTime <= 0)
        {
            Result.gameObject.SetActive(true);
            if(FactoryController.SuccessCount>=9)
               Result.text = "SUCCESS";
            else
            {
                Result.text = "FAILURE";
            }
                
        }
        else
        {
            Timer();
        }
    }
}
