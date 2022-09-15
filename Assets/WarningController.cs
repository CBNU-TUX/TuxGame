using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningController : MonoBehaviour
{
    [SerializeField]
    GameObject Warning;

    public void OnClick(){
        Warning.SetActive(false);
    }
}
