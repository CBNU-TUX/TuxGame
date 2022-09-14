using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Transfer : MonoBehaviour
{
    [Tooltip("Transfer Scene && Player Position")]
    [SerializeField]
    string GoTo;
    [SerializeField]
    Vector3 teleportPosition = new Vector3(0, 0, 0);
    [SerializeField]
    GameObject Warning;
    //When Moving the Scene, Stop the audio.

    //�̵��� ��ġ�� ���̸�

    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }
    void OnEnable(){
        if(SceneManager.GetActiveScene().name=="TreeZone"){
            GameObject.Find("Player").GetComponent<Animator>().SetTrigger("isTreeZone");
        }else{
            GameObject.Find("Player").GetComponent<Animator>().SetTrigger("isGeneral");
        }
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
        if(GlobalTimer.min>=6&&(GoTo=="TreeZone"||GoTo=="MainZone")){
            if (Input.GetKey(KeyCode.Space))
            {
              SceneTransition();
            }
        }else if(GlobalTimer.min>=6&&(GoTo!="TreeZone"||GoTo!="MainZone")){
            if (Input.GetKey(KeyCode.Space))
            {
                Warning.SetActive(true);
            }
        }else if (GlobalTimer.min<6&&Input.GetKey(KeyCode.Space))
        {
            if (Input.GetKey(KeyCode.Space))
            {
              SceneTransition();
            }
        }
        
    }
    public void SceneTransition()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        gameManager.setTransfer(GoTo);
        gameManager.ChangeScene(GoTo,teleportPosition);
        GameObject.Find("Player").GetComponent<Animator>().SetBool("isTreeZone",false);
    }
}
