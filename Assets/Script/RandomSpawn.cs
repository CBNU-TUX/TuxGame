using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject []trashs;

    int Spawnobj;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        SpawnPlay();
    }
    void SpawnPlay()
    {
        bool keydown = Input.GetKeyDown(KeyCode.Space);

        if (keydown)
        {
            Spawnobj = Random.Range(0, trashs.Length);
            Instantiate(trashs[Spawnobj], transform.position, Quaternion.identity);
        }

    }
}
