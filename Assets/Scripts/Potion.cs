using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public int PotionPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(Player.player.currentHealth < 100)
            {
                Player.player.TakeDamage(-PotionPoint);
                Destroy(this.gameObject);
            }
        }
    }
}
