using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

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
    
    public IEnumerator LoadMap(string transferMapName)
    {
        yield return new WaitForSeconds(0f);
        if (transferMapName != null)
        {
            SceneManager.LoadScene(transferMapName);
        }
    }
    public IEnumerator LoadMap()
    {
        if (transferScene != null)
        {
            yield return new WaitForSeconds(0f);
            SceneManager.LoadScene(transferScene);
        }
    }

    virtual public IEnumerator FadeOut(Vector3 teleportPosition = default(Vector3))
    {
        if (teleportPosition != default(Vector3)) // 0, 0, 0
            this.teleportPosition = teleportPosition;
        transitionAnimator.SetBool("FadeOut", true);
        transitionAnimator.SetBool("FadeIn", false);
        yield return new WaitForSeconds(0.5f);
        yield return new WaitForSeconds(transitionTime);
        StartCoroutine(AsyncLoadMap());
        yield return null;
    }

    virtual public IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(0.5f);

        
        if (teleportPosition != new Vector3(0, 0, 0))
            player.transform.position = teleportPosition;
        
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
        while (!async.isDone)
        {
            if (async.progress >= 0.9f)
            {
                async.allowSceneActivation = true;
                StartCoroutine(FadeIn());
            }
            yield return null;
        }
    }

    public Animator GetTransitionAnimator()
    {
        return GameObject.Find("GameManager").GetComponent<Animator>();
    }


}
