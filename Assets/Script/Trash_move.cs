using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash_move : MonoBehaviour
{
    Rigidbody2D rigid;
    public int nextMove;
    public int nextMove2;
    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();

        Invoke("Think", 1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigid.velocity = new Vector2 (nextMove, nextMove2);
        
    }
    void Think()
    {
        nextMove = Random.Range(-1, 2);
        nextMove2 = Random.Range(-1, 2);
        if (nextMove == 0 && nextMove2 == 0) 
        {
            Think();
        }
        Invoke("Think", 1);
    }
}
