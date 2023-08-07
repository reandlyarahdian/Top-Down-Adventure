using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    public bool grab;
    RaycastHit2D hit;
    public GameObject tower;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!grab)
            {
                hit = Physics2D.Raycast(transform.position, Vector2.up, 1f);

                if (hit.collider != null && hit.collider.tag == "Player")
                {
                    grab = true;
                }
            }
            else
            {
                grab = false;
                if (hit.collider.gameObject != null)
                {
                    hit.collider.transform.position = new Vector2(transform.localPosition.x, transform.localPosition.y -0.5f);
                }
            }
        }
        if (grab) transform.position = hit.collider.gameObject.transform.position;

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (hit.collider.gameObject != null)
            {
                Instantiate(tower, transform.position, transform.rotation);
            }
            else return;
        }
    }

    /*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grab)
            {
                trans = form;
            }
            else
            {
                trans.transform.position = new Vector2(transform.localPosition.x, transform.localPosition.y);
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "item")
        {
            form = collision.gameObject.transform;
            grab = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.transform == form)
        {
            form = null;
            grab = false;
        }
    }*/
}
