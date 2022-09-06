using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GrassController : MonoBehaviour
{
    Animator PlayerAni;
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayerAni = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name != "Player")
            return;

        if (Input.GetKey(KeyCode.Space))
        {
            PlayerAni.SetTrigger("isDigging");
            SoundManager.instance.platSE("shovel");
            PlayerMovement.canMove = false;
            Invoke("InactiveGrass", 1f);
        }
    }

    void InactiveGrass()
    {
        SoundManager.instance.platSE("shovel");
        PlayerMovement.canMove = true;
        this.gameObject.SetActive(false);
    }

}
