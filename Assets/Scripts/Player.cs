using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

	public int maxHealth = 100;
	public int currentHealth;

	public HealthBar healthBar;

    public static Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = this;
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
    }
    private void Update()
    {
        if (currentHealth <= 0)
        {
            Time.timeScale = 0;
            SceneManager.LoadScene(2);
        }
    }

    public void TakeDamage(int damage)
	{
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage(5);
            collision.gameObject.SendMessage("Damage", 10);
        }
    }

}
