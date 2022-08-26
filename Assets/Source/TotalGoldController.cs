using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TotalGoldController : MonoBehaviour
{
    public static int TotalGold=0;
    [SerializeField]
    Text TotalMoney;
    void Update(){
        TotalMoney.text=TotalGold.ToString();
    }
}
