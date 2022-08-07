using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class MoneyController : MonoBehaviour
{
    TotalGoldController tg;
    void Start(){
        tg=GameObject.Find("Money").GetComponent<TotalGoldController>();
    }
    void OnTriggerStay2D(Collider2D collision){
        tg.setGold(Dragable.gold);
        this.gameObject.SetActive(false);
    }
}
