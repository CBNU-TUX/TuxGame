using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
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
        GameObject transition = transform.Find("UI").Find("Transition").gameObject;
        transition.SetActive(true);
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
        try{
            if (transferScene != null)
            {
                //���� �÷��̾ ����. ���߿� �̸� Ǯ���ָ�ȴ�.
                player.CurrentMapName = transferScene;
            }
        }catch(NullReferenceException e){
            ;
        }
    }
/*  
    public IEnumerator LoadMap(string transferMapName)
    {
        yield return new WaitForSeconds(0f);
        if (transferMapName != null)
        {
            SceneManager.LoadScene("LoadMap");
        }
    }
    public IEnumerator LoadMap()
    {
        yield return null;
        Debug.Log("Load중");
        transform.Find("UI").Find("ProgressBar").gameObject.SetActive(true);
        AsyncOperation op=SceneManager.LoadSceneAsync(transferScene);
        op.allowSceneActivation=false;
        float timer=0.0f;
        while(!op.isDone){
            yield return null;
            timer+=Time.deltaTime;
            audio.Stop();
            if(op.progress<0.9f){
                progressBar.value=Mathf.Lerp(op.progress,1f, timer);
                if (progressBar.value >= op.progress)
                {
                    timer = 0f;
                }
            }
            else
            {
                progressBar.value = Mathf.Lerp(progressBar.value, 1f, timer); 
                if (progressBar.value == 1.0f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
        audio.Play();
        //if (transferScene != null)
        //{
        //    yield return new WaitForSeconds(0f);
        //    SceneManager.LoadScene(transferScene);
        //}
    }
*/
    virtual public void FadeOut(Vector3 teleportPosition = default(Vector3))
    {
        transform.Find("UI").Find("ProgressBar").gameObject.SetActive(true);
        if(transferScene!="SeaZone"){
            if (teleportPosition != default(Vector3)) // 0, 0, 0
                this.teleportPosition = teleportPosition;
        }else{
            player.transform.position= new Vector3(0, 0, 0);
        }
        
        transitionAnimator.SetBool("FadeOut", true);
        transitionAnimator.SetBool("FadeIn", false);
        //yield return new WaitForSeconds(0.5f);
        //yield return new WaitForSeconds(transitionTime);
        StartCoroutine(AsyncLoadMap());
        
    }

    virtual public IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(0.5f);

        if(transferScene!="SeaZone"){
            if (teleportPosition != new Vector3(0, 0, 0))
                player.transform.position = teleportPosition;
        }else{
            player.transform.position= new Vector3(0, 0, 0);
        }
        transitionAnimator.SetBool("FadeOut", false);
        transitionAnimator.SetBool("FadeIn", true);

        yield return new WaitForSeconds(0.5f);
        yield return new WaitForSeconds(transitionTime);
        transitionAnimator.SetBool("FadeOut", false);
        transitionAnimator.SetBool("FadeIn", false);
        yield return null;
    }

    virtual public IEnumerator AsyncLoadMap()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(transferScene);
        async.allowSceneActivation = false;
        float timer=0.0f;

        while (!async.isDone)
        {
            yield return null;
            timer+=Time.deltaTime;
            audio.Stop();
            if(async.progress<0.9f){
                progressBar.value=Mathf.Lerp(async.progress,1f, timer);
                if (progressBar.value >= async.progress)
                {
                    timer = 0f;
                }
            }
            else
            {
                progressBar.value = Mathf.Lerp(progressBar.value, 1f, timer);
                if (progressBar.value >= 0.99f)
                {
                    async.allowSceneActivation = true;
                    audio.Play();
                    break;
                }
            }
        }
        Debug.Log("???????????");
        StartCoroutine(FadeIn());
        transform.Find("UI").Find("ProgressBar").gameObject.SetActive(false);
    }

    public Animator GetTransitionAnimator()
    {
        return GameObject.Find("GameManager").GetComponent<Animator>();
    }


}
