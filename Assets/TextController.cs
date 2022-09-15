using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextController : MonoBehaviour
{

    public GameObject OneText;
    public GameObject ThreeText;
    public Text TwoText;
    public string narration;
    public float delay;

    bool isFirst;
    void Update(){
        if(!isFirst){
            if(OneText.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime>=0.99f){
                TwoText.gameObject.SetActive(true);
                StartCoroutine(Chat(narration));
                isFirst=true;
            }
        }
    }

    protected IEnumerator Chat(string narration)
    {
        string writerText = "";
        // 텍스트 타이핑 효과
        for (int a = 0; a < narration.Length; a++)
        {
            writerText += narration[a];
            TwoText.text = writerText;
            yield return new WaitForSeconds(delay);
        }
        ThreeText.SetActive(true);
    }
}