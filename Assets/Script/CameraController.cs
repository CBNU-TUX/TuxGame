using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject[] Player;
    // Start is called before the first frame update
    void Start()
    {
        Player= GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3((Player[0].transform.position.x + Player[1].transform.position.x)/2, (Player[0].transform.position.y + Player[1].transform.position.y)/2,-50);
    }
}
