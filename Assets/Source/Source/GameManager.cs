using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float transitionTime = 1f;
    protected Animator transitionAnimator;
    //PlayerMovement player;
    /*위치 조정을 위한 변수, 이동할 씬, 위치 변수*/
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
        //씬이동시 존재하는 오브젝트가 있음 삭제하기 위함.
        if (gameManagers.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        } // 중복된 GameMangager 오브젝트가 있을 경우 오브젝트 파괴
        GameObject transition = transform.Find("UI").Find("Transition").gameObject;
        transition.SetActive(true);
        //검은 화면을 띄워 자연스러움을 구현
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transferScene != null)
        {
            //현재 플레이어가 없음. 나중에 이를 풀어주면된다.
            //player.CurrentMapName = transferScene;
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

        /*
        if (teleportPosition != new Vector3(0, 0, 0))
            player.transform.position = teleportPosition;
        */
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
