using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject Player_2p;
    // Start is called before the first frame update
    void Start()
    {
        Player_2p=GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(Player_2p.transform.position.x, Player_2p.transform.position.y,-100f);
    }
}
