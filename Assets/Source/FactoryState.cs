using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryState : MonoBehaviour
{
    Animator animator;
    public bool isStarting = false;
    public bool isStoping = false;
    private void Start()
    {
        animator = GetComponent<Animator>();
        float randomTime = Random.Range(1f,5f);
        Invoke("randomTime", randomTime);
    }
    void randomTime()
    {
        if (!isStoping)
        {
            float randomTime = Random.Range(1f, 5f);
            float temp = Time.time * 100f;
            Random.InitState((int)temp);

            isStarting = true;
            animator.SetBool("isStarting", isStarting);
            Invoke("stop", 0.75f);
            Invoke("randomTime", randomTime);
        }
    }
    void stop()
    {
        
        isStarting = false;
        animator.SetBool("isStarting", isStarting);
        
    }
}
