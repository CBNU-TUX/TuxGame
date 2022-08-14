using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
    TotalGoldController tg;
    int gold=0;
    public Text don;
    void Start()
    {
        tg=GameObject.Find("Money").GetComponent<TotalGoldController>();
        don=GameObject.Find("MoneyUI").transform.GetChild(0).GetComponent<Text>();
        don.text = gold.ToString();
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        tg.setGold(Dragable.gold);
        gold += 50;
        don.text=gold.ToString();
        this.gameObject.SetActive(false);
    }
}
