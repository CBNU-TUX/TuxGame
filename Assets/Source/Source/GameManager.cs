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
    string transferScene;
    [SerializeField]
    Vector3 teleportPosition = new Vector3(0, 0, 0);
    [SerializeField]
    Slider progressBar;
    [SerializeField]
    AudioSource audio;

    public CanvasGroup Fade_img;
    float fadeDuration=2f;

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

        //GameObject transition = transform.Find("UI").Find("Transition").gameObject;
        //transition.SetActive(true);
        //���� ȭ���� ��� �ڿ��������� ����
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
                //���� �÷��̾ ����. ���߿� �̸� Ǯ���ָ�ȴ�.
                player.CurrentMapName = transferScene;
            }
        }catch(NullReferenceException e){
            ;
        }
    }

    private void OnDestroy() 
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // 이벤트에서 제거*
    }


    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Fade_img.DOFade(0, fadeDuration)
        .OnStart(()=>{
            progressBar.gameObject.SetActive(false);
        })
        .OnComplete(()=>{
             Fade_img.blocksRaycasts = false;
        });
        audio.Play();
    }

    virtual public void ChangeScene(string transferScene,Vector3 teleportPosition = default(Vector3)){
        try{
            
            Fade_img.DOFade(1,fadeDuration).OnStart(()=>{
                Fade_img.blocksRaycasts=true;
            })
            .OnComplete(()=>{
                    if(transferScene!="SeaZone"){
                    if (teleportPosition != default(Vector3)) // 0, 0, 0
                        this.teleportPosition = teleportPosition;
                }else{
                    player.transform.position= new Vector3(0, 0, 0);
                }
                StartCoroutine("AsyncLoadMap",transferScene);
            });   
        }catch(NullReferenceException e){

        }
    }
    virtual public IEnumerator AsyncLoadMap()
    {
        progressBar.gameObject.SetActive(true);

        AsyncOperation async = SceneManager.LoadSceneAsync(transferScene);
        async.allowSceneActivation = false;

        float timer=0.0f;

        while (!async.isDone)
        {
            yield return null;

            timer+=Time.deltaTime;
            audio.Stop();
            
            if(async.progress<0.9f){
                progressBar.value=Mathf.MoveTowards(progressBar.value,0.9f, timer);
                if (progressBar.value >= async.progress)
                {
                    timer = 0f;
                }
            }
            else
            {
                progressBar.value =Mathf.MoveTowards(progressBar.value,1f, timer);
                if (progressBar.value >= 0.99f)
                {
                    async.allowSceneActivation = true;
                    break;
                }
            }
        }
        async.allowSceneActivation = true;
    
    }

    public Animator GetTransitionAnimator()
    {
        return GameObject.Find("GameManager").GetComponent<Animator>();
    }


}
