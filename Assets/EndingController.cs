using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingController : MonoBehaviour
{
    int treeCount=0;
    // Start is called before the first frame update
    void Start()
    {
        foreach(SoilInfo t in PlayerWorking.working){
            Debug.Log(t.treelevel+" 엔딩");
            if(t.isEnd){
                treeCount++;
            }
            Debug.Log(treeCount+" 엔딩");
        }
        Debug.Log("트리의 갯수 "+ treeCount);
        
        if(treeCount<=8){
            this.transform.GetChild(2).gameObject.SetActive(true);
        }else if(treeCount<=16){
            this.transform.GetChild(1).gameObject.SetActive(true);
        }else{
            this.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

}
