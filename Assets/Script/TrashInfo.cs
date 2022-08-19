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
    double height;
    [SerializeField]
    double weight;
    [SerializeField]
    int coin;



    public string getType()
    {
        return type;
    }
    public double getheight()
    {
        return height;
    }
    public double getweight()
    {
        return weight;
    }

}
