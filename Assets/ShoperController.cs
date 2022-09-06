using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoperController : MonoBehaviour
{

    [SerializeField]
    GameObject[] UIPanel;

    bool []isCheck;
    void Start(){
        isCheck = new bool[7];
    }

    private void OnTriggerStay2D(Collider2D other) {
        int i=0;
        if(Input.GetKey(KeyCode.Space)&&!isCheck[0]){
            //UIPanel.SetActive(true);
            foreach(GameObject tmp in UIPanel){
                isCheck[i++]=true;
                tmp.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        int i=0;
        foreach(GameObject tmp in UIPanel){
                isCheck[i++]=false;
                tmp.SetActive(false);
        }
    }

    private void Update() {
        int i=0;
        if(isCheck[0]&&Input.GetKey(KeyCode.Escape)){
            foreach(GameObject tmp in UIPanel){
                isCheck[i++]=false;
                tmp.SetActive(false);
            }
        }    
    }
}
