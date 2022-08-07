using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TotalGoldController : MonoBehaviour
{
     [SerializeField]
    private Text gold;
    private int totalGold=0;
    public GameObject[] money;
    
    public void setGold(int gold){
        totalGold+=gold;
        this.gold.text=totalGold.ToString();
        Dragable.gold=0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Dragable.gold!=0){
            money[0].SetActive(true);
            Debug.Log(Dragable.gold);
        }
    }
}
