using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public float transitionTime = 1f;
    protected Animator transitionAnimator;
    PlayerMovement player;
    /*��ġ ������ ���� ����, �̵��� ��, ��ġ ����*/
    [SerializeField]
    public string transferScene;
    [SerializeField]
    Vector3 teleportPosition = new Vector3(0, 0, 0);
    [SerializeField]
    Slider progressBar;
    [SerializeField]
    AudioSource audio;
    [SerializeField]
    Text Loading;
    [SerializeField]
    Sprite[] img;

    public CanvasGroup Fade_img;
    float fadeDuration=2f;

    bool isCheck=false;
    AsyncOperation async;
    
    public void setTransfer(string transfer)
    {
        this.transferScene = transfer;
    }
    private void Awake()
    {   
        
        GameObject[] gameManagers = GameObject.FindGameObjectsWithTag("GameManager");
        //���̵��� �����ϴ� ������Ʈ�� ���� �����ϱ� ����.
        if (gameManagers.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        } // �ߺ��� GameMangager ������Ʈ�� ���� ��� ������Ʈ �ı�

        SceneManager.sceneLoaded += OnSceneLoaded; // 이벤트에 추가

    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerMovement>();
        transitionAnimator=this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            if (transferScene != null)
            {
                player = GameObject.FindObjectOfType<PlayerMovement>();
                if(player!=null){
                    player.CurrentMapName = transferScene;
                }
                
            }
        }catch(NullReferenceException e){
            ;
        }
    }

    private void OnDestroy() 
    {
        isCheck=false;
        SceneManager.sceneLoaded -= OnSceneLoaded; // 이벤트에서 제거*
    }


    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Fade_img.DOFade(0, fadeDuration)
        .OnStart(()=>{
            audio.Stop();
            if(player!=null){
                player.transform.position = teleportPosition;
                Debug.Log(teleportPosition+" "+player.transform.position); 
            }  
        })
        .OnComplete(()=>{
            progressBar.gameObject.SetActive(false);
            audio.Play();
            isCheck=false;
            Fade_img.blocksRaycasts = false;
        });
        
    }

    virtual public void ChangeScene(string transferScene){
        try{
            if(transferScene=="TreeZone"){
                Fade_img.GetComponent<Image>().sprite=img[0];
            }else if(transferScene=="TrashZone"){
                Fade_img.GetComponent<Image>().sprite=img[1];    
            }else if(transferScene=="SeaZone"){
                Fade_img.GetComponent<Image>().sprite=img[2];
            }else if(transferScene=="FactoryZone"){
                Fade_img.GetComponent<Image>().sprite=img[3];
            }else{
                Fade_img.GetComponent<Image>().sprite=img[4];
            }

            Fade_img.DOFade(1,fadeDuration).OnStart(()=>{
                Fade_img.blocksRaycasts=true;
            })
            .OnComplete(()=>{
                if(!isCheck){
                    isCheck=true;
                    StartCoroutine("AsyncLoadMap",transferScene);
                }
            });   
        }catch(NullReferenceException e){

        }
    }

    virtual public void ChangeScene(string transferScene,Vector3 teleportPosition = default(Vector3)){

        try{

            if(transferScene=="TreeZone"){
                Fade_img.GetComponent<Image>().sprite=img[0];
            }else if(transferScene=="TrashZone"){
                Fade_img.GetComponent<Image>().sprite=img[1];    
            }else if(transferScene=="SeaZone"){
                Fade_img.GetComponent<Image>().sprite=img[2];
            }else if(transferScene=="FactoryZone"){
                Fade_img.GetComponent<Image>().sprite=img[3];
            }else{
                Fade_img.GetComponent<Image>().sprite=img[4];
            }

            Fade_img.DOFade(1,fadeDuration).OnStart(()=>{
                Fade_img.blocksRaycasts=true;
            })
            .OnComplete(()=>{
                if(transferScene!="SeaZone"){
                   if(player!=null)
                        player.transform.position = teleportPosition;
                   this.teleportPosition = teleportPosition;
                }else{
                    player.transform.position= new Vector3(0, 0, 0);
                }
                if(!isCheck){
                    isCheck=true;
                    StartCoroutine("AsyncLoadMap",transferScene);
                }
            });   
        }catch(NullReferenceException e){

        }
    }
    
    virtual public IEnumerator AsyncLoadMap()
    {
        
        progressBar.gameObject.SetActive(true);

        async = SceneManager.LoadSceneAsync(transferScene);
        async.allowSceneActivation = false;

        float timer=0.0f;

        while (!async.isDone)
        {
                yield return null;

                timer+=Time.deltaTime;
                
                
                if(progressBar.value<0.9f){
                    
                    progressBar.value= Mathf.MoveTowards(progressBar.value,0.9f,timer);

                    if (progressBar.value >= async.progress)
                    {
                        timer = 0f;
                    }
                }else
                {
                    Loading.text="SpaceBar...";
                }
                
                if(async.progress>=0.9f){
                    progressBar.value= Mathf.MoveTowards(progressBar.value,1f,timer);
                }

                if(Input.GetKey(KeyCode.Space)&&progressBar.value>=1f&&async.progress>=0.9f){
                    async.allowSceneActivation = true;
                    break;
            }
        }
        
        async.allowSceneActivation = true;
    }


}
