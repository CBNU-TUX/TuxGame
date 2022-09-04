using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoperController : MonoBehaviour
{

    [SerializeField]
    GameObject UIPanel;

    bool isCheck;
    void Start(){
        isCheck=false;
    }
    private void OnTriggerStay2D(Collider2D other) {

        if(Input.GetKey(KeyCode.Space)&&!isCheck){
            UIPanel.SetActive(true);  
            isCheck=true;
        }
    }

    private void Update() {
        if(isCheck&&Input.GetKey(KeyCode.Escape)){
            isCheck=false;
            UIPanel.SetActive(false);
        }    
    }
}
