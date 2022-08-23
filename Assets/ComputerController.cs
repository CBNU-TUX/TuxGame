using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ComputerController : MonoBehaviour
{
   [SerializeField]
    GameObject MailUI;
    
    void OnTriggerStay2D(Collider2D collision){
        if(Input.GetKey(KeyCode.Space)){
            MailUI.SetActive(true);
        }
    }
}
