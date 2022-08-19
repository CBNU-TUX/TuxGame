using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassController : MonoBehaviour
{
    
    void OnTriggerStay2D(Collider2D collision){

        if(collision.name != "Player")
            return ;
        
        if(Input.GetKey(KeyCode.Space))
        {
            this.gameObject.SetActive(false);
        }
    }
}
