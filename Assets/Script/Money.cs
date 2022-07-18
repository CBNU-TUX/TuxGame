using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public Text label;

    int gold = 500;

    void Start()
    {

    }

    // Update is called once per frame
    void DisplayGold()
    {
        label.text = gold.ToString();
    }
    public void MinusGold()
    { 
        gold -= 10;
        DisplayGold();
    }
}
