using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class MailController : MonoBehaviour
{
    [SerializeField]
    GameObject MailUI;
    [SerializeField]
    GameObject White;
    [SerializeField]
    GameObject Grey;
    int RandCount;

    ArrayList mail;

    void Start(){
        mail=new ArrayList();
        RandCount=Random.Range(2,20); //스크롤방법을 알아내면 더 늘어날 예정
        MailUI.transform.Find("Count").GetComponent<Text>().text=RandCount.ToString();

        mail.Add(Grey);
        mail.Add(White);
        for(int i=2;i<RandCount;i++){
            GameObject tmp;
            if(i%2==0){
                tmp= Instantiate(Grey,transform.position,Quaternion.identity,GameObject.Find("Panel").transform) as GameObject;
            }
            else
            {
                tmp= Instantiate(White,transform.position,Quaternion.identity,GameObject.Find("Panel").transform) as GameObject;
            }
            mail.Add(tmp);
        }
        
    }

    public void OnButton(){
        GameObject.Find("Window").gameObject.SetActive(false);
    }
    
    public void ExitClick(){
        GameObject exit=EventSystem.current.currentSelectedGameObject;

        Debug.Log(exit.transform.parent.name);

        Destroy(exit.transform.parent.gameObject);
        
        foreach(GameObject m in mail){
            if(m.name==exit.transform.parent.name){
                Debug.Log("찾음");
                mail.Remove(m);
                break;
            }
        }
        MailUI.transform.Find("Count").GetComponent<Text>().text=mail.Count.ToString();
    }
}
