using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;
public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField]
    GameObject sleepPlayer;

    Animator animator;
    Rigidbody2D rigid;
    Vector2 move,direction;
    public string CurrentMapName;
    public string SceneName;
    // Start is called before the first frame update
    void Start()
    {
        animator=this.GetComponent<Animator>();
        rigid=this.GetComponent<Rigidbody2D>();
    }

  void OnEnable(){
    SceneManager.sceneLoaded+=OnSceneLoaded;
  }

  void OnSceneLoaded(Scene scene,LoadSceneMode mode)
  {
    Debug.Log("PlayerScript "+scene.name);
    if(scene.name=="HomeZone"){
        this.GetComponent<SpriteRenderer>().color=new Color(1,1,1,0);
        this.GetComponent<CapsuleCollider2D>().enabled=false;
    }
    sleepPlayer=GameObject.FindGameObjectWithTag("SleepPlayer");
  }

  void OnDisable(){
    SceneManager.sceneLoaded-=OnSceneLoaded;
  }
  private void Awake()
    {

        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        if (players.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        } // 중복된 Player 오브젝트가 있을 경우 오브젝트 파괴

        rigid = GetComponent<Rigidbody2D>();

    }
    // Update is called once per frame
    void Update()
    {
        SceneName = SceneManager.GetActiveScene().name;
        //animator.SetBool("isIdle",false);
        try
        {
            
        move.x=Input.GetAxisRaw("Horizontal");
        move.y=Input.GetAxisRaw("Vertical");

        animator.SetFloat("MoveSpeed", move.sqrMagnitude * speed);
        animator.speed = speed / 4; // 이동 속도의 4분의 1만큼의 빠르기로 애니메이션 재생

        if(move.sqrMagnitude>0){
            
            if(sleepPlayer!=null)
                sleepPlayer.gameObject.SetActive(false);

            this.GetComponent<SpriteRenderer>().color=new Color(1,1,1,1);
            this.GetComponent<CapsuleCollider2D>().enabled=true;
            direction.x=Input.GetAxisRaw("Horizontal");
            direction.y=Input.GetAxisRaw("Vertical");
            if (SceneName == "HomeZone") 
            {
                SoundManager.instance.platSE("WalkWood");
            }
            if (SceneName == "MainZone" || SceneName == "TreeZone")
            {
                SoundManager.instance.platSE("WalkDirt");
            }
        }
         if (animator.GetFloat("MoveSpeed") > 0)
            { 
                animator.SetFloat("MoveHorizontally", move.x);
                animator.SetFloat("MoveVertically", move.y);
            }

        }catch(NullReferenceException e){
            ;
        }
    }


     void FixedUpdate()
    {
        rigid.MovePosition(rigid.position + move * speed * Time.deltaTime);
    }

}
