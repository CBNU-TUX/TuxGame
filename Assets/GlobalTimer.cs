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
    Text minText;
    Text secText;

    [SerializeField]
    Light2D light;
    
    private float timerSpeed = 1.0f; //초 분위
    public static float timer=0f;
    
    // Start is called before the first frame update
    void Start()
    {
        minText = GameObject.FindGameObjectWithTag("MM").GetComponent<Text>();
        secText = GameObject.FindGameObjectWithTag("SS").GetComponent<Text>();
        minText.text=((int)min).ToString();
        secText.text=((int)min).ToString();
        Invoke("evening",10f);
    }

    void evening(){
        light.color= new Color(233f/255f,210f/255f,134f/255f,134f/255f);
        Invoke("night",10f);
    }
    void night(){
        light.color= new Color(200f/255f,200f/255f,200f/255f,134f/255f);
        Invoke("morning",10f);
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

        if (hours > 12)
            hours -= 12;

        if((min/10)==0)
            minText.text="0"+min.ToString();
        else
            minText.text=min.ToString();
        
        if((sec/10)==0)
            secText.text="0"+sec.ToString();
        else
            secText.text=sec.ToString();
            //Debug.Log(minutes);
    }

    public void Reset()
    {
        timer = 0;
    }
    
}
