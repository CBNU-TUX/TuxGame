using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaSpawner : MonoBehaviour
{
    public float spawnTime = 3f;
    public float curTime;
    public Transform[] spawnLocation;
    public GameObject []trashs;
    //public static bool spawn = false;
    int Spawnobj;
    // Start is called before the first frame update
    void Update()
    {
        if(curTime >= spawnTime)
        {
            int x = Random.Range(0,spawnLocation.Length);
            SpawnPlay(x);
        }
        curTime += Time.deltaTime;
    }
    // Update is called once per frame
    void SpawnPlay(int num)
    {
        Spawnobj = Random.Range(0, trashs.Length);
        curTime = 0;
        Instantiate(trashs[Spawnobj], spawnLocation[num], GameObject.Find("Ocean_Invisible").transform);
    }
}
