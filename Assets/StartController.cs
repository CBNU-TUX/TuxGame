using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField]
    string GoTo;

    public void OnClick(){
        Debug.Log("Go Start");
        gameManager = GameObject.FindObjectOfType<GameManager>();
        gameManager.setTransfer(GoTo);
        gameManager.ChangeScene(GoTo);
    }
}
