using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transfer : MonoBehaviour
{
    [Tooltip("Transfer Scene && Player Position")]
    [SerializeField]
    string GoTo;
    [SerializeField]
    Vector3 teleportPosition = new Vector3(0, 0, 0);
    //�̵��� ��ġ�� ���̸�

    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (TimerController.isEnding)
        {
            SceneTransition();
            TimerController.isEnding = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //StartCoroutine(deleayTime());
            SceneTransition();
        }
    }
    public void SceneTransition()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        gameManager.setTransfer(GoTo);
        StartCoroutine(gameManager.FadeOut(teleportPosition));
    }
}
