using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyController : MonoBehaviour
{

    void OnTriggerStay2D(Collider2D collision){
        if(collision.tag!="Player")
            return ;

        this.gameObject.SetActive(false); 
    }
}
