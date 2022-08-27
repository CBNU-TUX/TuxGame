using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapController : MonoBehaviour
{
    [SerializeField]
    GameObject MiniMap;
    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(MiniMap.transform.position.x,MiniMap.transform.position.y,-20);
    }
}
