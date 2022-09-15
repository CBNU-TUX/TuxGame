using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingController : MonoBehaviour
{
    int treeCount=0;

    void Start()
    {
        treeCount = PlayerWorking.Trees.Count;
        Debug.Log("tree의 수"+PlayerWorking.Trees.Count.ToString());
        if(treeCount<=8){
            this.transform.GetChild(2).gameObject.SetActive(true);
            
        }else if(treeCount<=16){
            this.transform.GetChild(1).gameObject.SetActive(true);
            
        }else{
            this.transform.GetChild(0).gameObject.SetActive(true);
            
        }

        
    }

}
