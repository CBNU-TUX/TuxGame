using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
public class LightController : MonoBehaviour
{

    [SerializeField]
    Light2D light;
    bool isFirst;
    private void Awake()
    {
        GameObject[] Light = GameObject.FindGameObjectsWithTag("Light");
        if (Light.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        } // 중복된 Player 오브젝트가 있을 경우 오브젝트 파괴
        Invoke("morning",1f);
    }
    void Update(){
        if(GlobalTimer.min<=0f)
            Invoke("morning",1f);
    }
    void evening()
    {
       light.color = new Color(233f / 255f, 210f / 255f, 134f / 255f, 134f / 255f);
       Invoke("night",120f); //2분뒤
    }
    void night()
    {
        light.color = new Color(159f / 255f, 159f / 255f, 159f / 255f, 134f / 255f);
        Invoke("morning",80f);
       
    }
    void morning()
    {
        light.color = new Color(1f, 1f, 1f, 134f / 255f);
        Invoke("evening",240f); //4분뒤
    }

}
