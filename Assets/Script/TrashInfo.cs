using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashInfo : MonoBehaviour
{
    [SerializeField]
    string name;
    [SerializeField]
    string type;
    [SerializeField]
    int coin;



    public string getType()
    {
        return type;
    }

    public int GetCoin()
    {
        return coin;
    }



}
