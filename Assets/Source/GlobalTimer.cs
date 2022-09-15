using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
public class GlobalTimer : MonoBehaviour
{
    static int hours;
    static int sec;
    public static int min;
    public static int day=3;
    Text minText;
    Text secText;

    [SerializeField]
    Text Calender;
    [SerializeField]
    Image Calender_img;
    [SerializeField]
    Sprite img;

    [SerializeField]
    string GoTo;
    [SerializeField]
    Vector3 teleportPosition = new Vector3(0, 0, 0);

    private float timerSpeed = 1.0f; //초 분위
    public static float timer = 0f;
    string[] days = { "일", "이", "삼", "사", "오" };
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        minText = GameObject.FindGameObjectWithTag("MM").GetComponent<Text>();
        secText = GameObject.FindGameObjectWithTag("SS").GetComponent<Text>();
        minText.text = ((int)min).ToString();
        secText.text = ((int)min).ToString();
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void Update()
    {
        timer += Time.deltaTime * timerSpeed;
        DisplayTime();

    }

    void DisplayTime()
    {

        if (timer >= 60.0f * 60.0f)
        {
            timer -= 60.0f * 60.0f;
        }

        min = Mathf.FloorToInt(timer / 60.0f - hours * 60);
        sec = Mathf.FloorToInt(timer - min * 60 - hours * 60.0f * 60.0f);

        //10을 1로 바꿈
        if (min >= 7)
        {
            Reset();
            min = 0;
            day += 1;
            SceneTransition();
        }


        if ((min / 10) == 0)
            minText.text = "0" + min.ToString();
        else
            minText.text = min.ToString();

        if ((sec / 10) == 0)
            secText.text = "0" + sec.ToString();
        else
            secText.text = sec.ToString();
        //Debug.Log(minutes);

        if (day <= 4)
        {
            Calender.text = days[day];
        }else{
            SceneTransition_Ending();
        }

        if (Calender.text != "일")
        {
            Calender_img.sprite = img;
        }
    }

    public void Reset()
    {
        timer = 0;
    }
    
    public void SceneTransition_Ending()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        gameManager.setTransfer("Ending");
        gameManager.ChangeScene("Ending",new Vector3(10.28f,7.74f,0f));
        GameObject.Find("Player").GetComponent<Animator>().SetBool("isTreeZone",false);
    }

    public void SceneTransition()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        gameManager.setTransfer("HomeZone");
        gameManager.ChangeScene("HomeZone",new Vector3(10.28f,7.74f,0f));
        GameObject.Find("Player").GetComponent<Animator>().SetBool("isTreeZone",false);
    }
}
