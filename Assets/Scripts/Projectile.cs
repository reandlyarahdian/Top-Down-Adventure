using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage;
    public float count;
    public float hit;

    private void Update()
    {
        hit += Time.deltaTime;
        if (hit > count)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            collision.SendMessage("Damage", damage);
            Destroy(gameObject);
        }
    }
}
