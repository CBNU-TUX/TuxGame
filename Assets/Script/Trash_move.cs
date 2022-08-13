using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trash_move : MonoBehaviour
{
    Rigidbody2D rigid;
    static int gold = 0;
    //public Text text;
    public Text don;
    public int nextMove;
    public int nextMove2;
    public GameObject net;
    GameObject Boat;
    bool isCollider=false;
    static public bool isFishing=false;
    Vector3 offset;
    // Start is called before the first frame update
    private void Start()
    {
        Invoke("Think", 1);
        don.text = gold.ToString();
    }
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        Boat = GameObject.Find("Boat");
        offset=this.transform.position-Boat.transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision) //Net�� ������� �浹�������
    {
        if (collision.gameObject.tag == "Net") 
        {
            isCollider = true;
            rigid.velocity =Vector3.forward;
            Debug.Log("qnn");
        }
        if (collision.name == "Collision" && isFishing)
        {
            gold += 50;
            don.text=gold.ToString();
            gameObject.SetActive(false);
            Invoke("Endfihsing", 0.3f);
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        isCollider=false;
        Think();
    }
    void Update(){
        if(isCollider)
            if(isFishing)
            {
                transform.position = Vector3.MoveTowards(gameObject.transform.position,Boat.transform.position, 0.01f);    
            }
    }
    void FixedUpdate()
    {
        if (!isCollider)
        {
            rigid.velocity = new Vector2(nextMove, nextMove2);
        }
        else
        {
            rigid.velocity = new Vector2(0, 3);
        }
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
            Invoke("Think", 1);
        }
    }
    void Endfihsing()
    {
        isFishing=false;
    }
}
