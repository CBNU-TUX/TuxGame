using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class SoilInfo : MonoBehaviour
{
    public string name;
    public int level;
    public string treelevel;
    public float timer;
    private float timerSpeed = 1.0f; //초 분위
    public bool isGrowing=false;

    public void setImg(Sprite img){
        this.gameObject.GetComponent<SpriteRenderer>().sprite=img;
    }

    void OnEnable()
    {
        try{
            foreach(SoilInfo tmp in PlayerWorking.working){
                if(tmp.name==this.name){
                    this.isGrowing=tmp.isGrowing;
                    this.treelevel=tmp.treelevel;
                    this.timer=tmp.timer;
                    Debug.Log("씬 변경 시"+this.timer);
                }
            }
        }catch(NullReferenceException e){
            ;
        }
    	  // 씬 매니저의 sceneLoaded에 체인을 건다.
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Update(){
        if(isGrowing&&treelevel=="seed"){
            timer += Time.deltaTime * timerSpeed;
            if(timer<=1f){
                Invoke("GrowSeed",60f);
            }else if(Mathf.FloorToInt(timer)>=60){
                GrowSeed();    
            }
        }else if(isGrowing&&treelevel=="sprout")
        {
           timer += Time.deltaTime * timerSpeed;
            if(timer<=1f)
                Invoke("GrowSprout",30f);
            else if(Mathf.FloorToInt(timer)>=30){
                GrowSprout();    
            }
        }
    }
    void GrowSeed(){
        this.gameObject.transform.Find("seed").gameObject.SetActive(false);
        this.treelevel="sprout";
        this.gameObject.transform.Find(this.treelevel).gameObject.SetActive(true);
        this.isGrowing=false;
        Invoke("GrowSprout",15f);
    }

    public void GrowSprout(){
        this.gameObject.transform.Find("sprout").gameObject.SetActive(false);
        this.treelevel="tree";
        this.gameObject.transform.Find(this.treelevel).gameObject.SetActive(true);
        isGrowing=false;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode){

        try{
            foreach (SoilInfo tmp in PlayerWorking.working)
            {
                Debug.Log(tmp.name+" "+this.name);
                if(this.name==tmp.name){
                    this.timer=tmp.timer+GlobalTimer.timer;
                    this.level=tmp.level;
                    this.gameObject.GetComponent<SpriteRenderer>().sprite=Soil.levelImg[tmp.level];
                    this.treelevel=tmp.treelevel;
                    if(treelevel!="No"){
                        this.gameObject.transform.Find(tmp.treelevel).gameObject.SetActive(true);
                    }
                }
            }
        }catch(NullReferenceException){
            ;
        }
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        try{
            foreach(SoilInfo tmp in PlayerWorking.working){
                if(tmp.name==this.name){
                    if(tmp.treelevel=="sprout"){
                        tmp.timer=GlobalTimer.timer-this.timer;
                        tmp.timer+=60f;
                    }else{
                        tmp.timer=GlobalTimer.timer-this.timer;
                        Debug.Log(tmp.name+" : "+tmp.timer);
                    }
                }
            }
        }catch(NullReferenceException e){
            ;
        }
    }

/*
     void DisplayTime()
    {

        if (timer >= 60.0f * 60.0f)
        {
            timer -= 60.0f * 60.0f;
        }

        min = Mathf.FloorToInt(timer / 60.0f - hours * 60);
        sec = Mathf.FloorToInt(timer - min * 60 - hours * 60.0f * 60.0f);

        if (min >= 10)
        {
            min -= 10;
            day += 1;
        }    
    }*/
    /*
    나무심기에선 레벨 5단계로 나눈다.
    
    초기레벨은 0단계
    1단계 삽 (공통적인 것) -> 레벨 1부터는 삽 사용이 불가 0일때만 사용 할 수 있다.
    2단계 씨앗 
        물주기: 5회 (기본)
        일 수: 5일
        자라는 기준 1일차 -> 2일차 (모종) -> 3일차 (모종) ->4일차 (작은 나무) -> 5일차 나무
    3단계 모종 
        물주기 4회 (기본)
        일 수: 4일
        자라는 기준 1일차(모종) -> 2일차(모종) -> 3일차 (작은 나무) ->4일차 나무
    4단계 작은 나무
        물주기 2회 (기본)
        일 수: 2일
        자라는 기준 1일차(작은나무) -> 2일차(나무)
    5단계 완성
    천연 거름의 경우 하루의 절반(5분)더 빨리 성장할 수 있도록 함.  
    */


}
