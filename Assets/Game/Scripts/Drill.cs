using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drill : MonoBehaviour
{
    public bool IsTrigger = false;
    public Collider2D collision;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "mineable")
        {
            IsTrigger = true;
            this.collision = collision;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        IsTrigger = false;
    }
}
