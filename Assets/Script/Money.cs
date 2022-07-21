using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public Text label;
    int gold = 500;
    public static bool is_first=true;
    private void Update()
    {
        if (!is_first)
        {
            MinusGold();
        }
        DisplayGold();
    }
    // Update is called once per frame
    void DisplayGold()
    {
        label.text = ((int)gold).ToString();
    }
    public void MinusGold()
    {
        if (!Slot.is_Right && Dragable.is_Close)
        {
            gold -= 50;
        }
        is_first = true;
    }
}
