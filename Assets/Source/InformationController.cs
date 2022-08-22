using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class InformationController : MonoBehaviour
{
    [SerializeField]
    GameObject Sign;
    [SerializeField]
    int field;
    [SerializeField]
    Text Infor;
    // Start is called before the first frame update
   
    void OnTriggerStay2D(Collider2D collision){
     
        Debug.Log(collision.name);
        try{
            if(Input.GetKey(KeyCode.Space)){
                Sign.SetActive(true);
            }
            
            switch(field){
                case 1:
                    Infor.text=" 이 구간은 공장단지입니다.\n\n우리나라는 국민의 건강과 환경을 보호하기 위한 목적으로 대기 환경보존법을 개정하였습니다.\n\n플레이어는 이를 무시하고, 매연을 방출하는 공장에게 마우스을 이용해, 과태료를 부과하세요.";
                    break;
                case 2:
                    Infor.text=" 이 구간은 해양구역입니다.\n\n해양쓰레기 문제의 심각성은 발생량의 많고 적음이 아니라 발생된 이후 쓰레기가 미치는 영향의 범위와 대상이 확대되고 있다는 것입니다. \n\n플레이어는 스페이스바를 이용해 그물을 던져, 쓰레기를 회수해 주세요.";
                    break;
                case 3:
                    Infor.text=" 이 구간은 회수된 쓰레기들을 분리수거하는 장소입니다.\n\n플레이어는 올바른 분리수거 방법이 무엇인지 생각하여 쓰레기를 올바른 쓰레기통에 옮겨주세요.\n\n분리배출표시 도안이 개정되었습니다. 이를 고려해주세요.";
                    break;
                case 4:
                    Infor.text=" 이 구간은 나무를 심는 장소입니다.\n\n 올바른 나무심기는 미세먼지와 대기오염을 줄일 수 있습니다. 현재 자금을 이용해 18그루를 심어주세요.\n\n씨앗, 5일 / 모종, 4일 /이동 나무 3일 걸립니다.물과 천연거름을 적절히 분배하여 키워주세요.";
                    break;
            }
        }catch(NullReferenceException e){
            ;
        }
        
    }
    void Update(){
        try{  
            if(Input.GetKey(KeyCode.Escape)&&Sign.activeSelf){
                Sign.SetActive(false);
            }
        }catch(NullReferenceException e){
            ;
        }
        

    }
}
