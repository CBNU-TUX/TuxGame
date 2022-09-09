using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpaceController : MonoBehaviour
{
   [SerializeField]
    GameObject Ui;
    
    void OnTriggerStay2D(Collider2D collision){
        if(Input.GetKey(KeyCode.Space))
        {
            SoundManager.instance.platSE("computerON");
            Ui.SetActive(true);
        }
    }
    
    void Update(){

        if(Input.GetKey(KeyCode.Escape)){
            if(Ui.activeSelf)
            {
                SoundManager.instance.platSE("computerOFF");
                Ui.SetActive(false);
            }
        }
    }
}
