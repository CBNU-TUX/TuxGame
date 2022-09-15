using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
public class LightController : MonoBehaviour
{

    [SerializeField]
    Light2D light;
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
        Invoke("evening", 210f); //3.5분 
    }
    
    void evening()
    {
       light.color = new Color(233f / 255f, 210f / 255f, 134f / 255f, 134f / 255f);
        Invoke("night", 150f); //2.5
    }
    void night()
    {
        light.color = new Color(159f / 255f, 159f / 255f, 159f / 255f, 134f / 255f);
        Invoke("morning", 70f); //1
    }
    void morning()
    {
        light.color = new Color(1f, 1f, 1f, 134f / 255f);
        Invoke("evening", 210f); //2.5
    }

}
