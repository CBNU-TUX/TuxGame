using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash_move : MonoBehaviour
{
    Rigidbody2D rigid;
    //public Text text;

    public int nextMove;
    public int nextMove2;
    public GameObject net;
    GameObject Boat;
    bool isCollider=false;

    // Start is called before the first frame update
    private void Start()
    {
        Invoke("Think", 1);
    }
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        Boat = GameObject.Find("Boat");
    }
    private void OnTriggerEnter2D(Collider2D collision) //Net�� ������� �浹�������
    {
        if (collision.gameObject.tag == "Net") 
        {
            isCollider = true; 

            return;
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision){
        isCollider=false;
        Think();
    }

    //void Update(){
    //    if(isCollider)
    //        if(FishingController.isFishing)
    //        {
    //            transform.position = Vector3.MoveTowards(gameObject.transform.position,Boat.transform.position, 0.01f);    
    //        }
    //}
    void FixedUpdate()
    {
        if (!isCollider)
        {
            rigid.velocity = new Vector2(nextMove, nextMove2);
        }else
        {
            rigid.velocity = new Vector2(0, 3);
        }

        Vector3 pos=Camera.main.WorldToViewportPoint(transform.position);  
        //카메라 -> 플레이어를 따라감
        //씬을 넘어갈때도 플레이어가 필요함.
        //플레이어 자체가 파괴하지않게함. -> 해양씬에서 플레이어가없으면 모든씬 오류가 발생
        //쓰레기존, 해양씬, 공장씬 에서는 플레이어가 없어도됌 -> 플레이어를 안쪽에넣고 (배경화면)
        //해양씬 카메라 -> 플레이어를 따라감. 
        //pos -> 카메라의 뷰포트를 찾음 
        //플레이어가 잘못된 위치에 있으면 쓰레기가 뭉쳐서나옴 
        if(pos.x<0f) pos.x=0.2f;
        if(pos.x>1f) pos.x=0.8f;
        if(pos.y<0f) pos.y=0.2f;
        if(pos.y>0.55f) pos.y=0.45f;

        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    void Think()
    {

        nextMove = Random.Range(-1, 2);
        nextMove2 = Random.Range(-1, 2);
        if (nextMove == 0 && nextMove2 == 0 && !isCollider)
        {
            Think();
        }
        if (!isCollider)
        {
            Invoke("Think", 2f);
        }
    }
}
