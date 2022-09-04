using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject []trashs;
    public static bool spawn = false;
    int Spawnobj;
    // Start is called before the first frame update
    void Start()
    {
        SpawnPlay();
    }
    // Update is called once per frame
    void Update()
    {
        if (spawn)
            SpawnPlay();
    }
    void SpawnPlay()
    {
        Spawnobj = Random.Range(0, trashs.Length);
        Instantiate(trashs[Spawnobj], transform.position, Quaternion.identity, GameObject.Find("Trashes").transform);
        spawn = false;
    }
    //void SpwanPlay()
    //{
    //    bool keydown = Input.GetKeyDown(KeyCode.Space);

    //    if (keydown)
    //    {
    //        SpawnObj = Random.Range(1, 7);

    //        switch (SpawnObj)
    //        {
    //            case 1:
    //                Instantiate(sushi1, transform.position, Quaternion.identity);
    //                break;
    //            case 2:
    //                Instantiate(sushi2, transform.position, Quaternion.identity);
    //                break;
    //            case 3:
    //                Instantiate(sushi3, transform.position, Quaternion.identity);
    //                break;
    //            case 4:
    //                Instantiate(sushi4, transform.position, Quaternion.identity);
    //                break;
    //            case 5:
    //                Instantiate(sushi5, transform.position, Quaternion.identity);
    //                break;
    //            case 6:
    //                Instantiate(sushi6, transform.position, Quaternion.identity);
    //                break;
    //        }
    //    }
    //}
}
