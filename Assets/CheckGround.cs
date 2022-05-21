using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{

    public bool isChecking = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isChecking = true;
    }
}
