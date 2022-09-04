using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MapClickController : MonoBehaviour
{
    
    [SerializeField]
    GameObject miniMap;
    
    public void onClick(){

        miniMap.SetActive(true);

        this.gameObject.SetActive(false);
    }
}
