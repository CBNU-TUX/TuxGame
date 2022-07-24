using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GlobalTimer : MonoBehaviour
{   
    static int hours;
    static int sec;
    static int min;
    static int day;
    Text minText;
    Text secText;

    [SerializeField]
    Light2D light;
    [SerializeField]
    Text Calender;
    [SerializeField]
    Image Calender_img;
    [SerializeField]
    Sprite img;

    private float timerSpeed = 1.0f; //초 분위
    public static float timer=0f;
    string []days={"일","이","삼","사","오"};

    // Start is called before the first frame update
    void Start()
    {
        minText = GameObject.FindGameObjectWithTag("MM").GetComponent<Text>();
        secText = GameObject.FindGameObjectWithTag("SS").GetComponent<Text>();
        minText.text=((int)min).ToString();
        secText.text=((int)min).ToString();
        
        Invoke("evening",180f);
    }

    void evening(){
        light.color= new Color(233f/255f,210f/255f,134f/255f,134f/255f);
        Invoke("night",180f);
    }
    void night(){
        light.color= new Color(159f/255f,159f/255f,159f/255f,134f/255f);
        Invoke("morning",240f);
    }
    void morning(){
        light.color= new Color(1f,1f,1f,134f/255f);
        Invoke("evening",180f);
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

        if (min >= 10){
            min -= 10;
            day+=1;
        }

        if((min/10)==0)
            minText.text="0"+min.ToString();
        else
            minText.text=min.ToString();
        
        if((sec/10)==0)
            secText.text="0"+sec.ToString();
        else
            secText.text=sec.ToString();
            //Debug.Log(minutes);

        if(day<=4){
            Calender.text=days[day];
        }

        if(Calender.text!="일"){
            Calender_img.sprite=img;
        }
    }

    public void Reset()
    {
        timer = 0;
    }
    
}
