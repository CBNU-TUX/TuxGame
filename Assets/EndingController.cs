using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerWorking.treeCount<=8){
            this.transform.GetChild(2).gameObject.SetActive(true);
        }else if(PlayerWorking.treeCount<=15){
            this.transform.GetChild(1).gameObject.SetActive(true);
        }else{
            this.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

}
