using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashInfo : MonoBehaviour
{
    [SerializeField]
    string name;
    [SerializeField]
    string type;

    public string getType(){
        return type;
    }
    
}
