using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject Prefab;
    public float SpawnRate;
    public float Speed = 2500.0f;
    public float timer;
    [SerializeField]
    private GameObject parent;
    private float Reset;
    [SerializeField]
    private Collider2D enemyCol;

    void Start()
    {
        Reset = SpawnRate;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (0 >= timer)
        {
            Destroy(parent);
        }
        else
        {
            fireProjectile();
            SpawnRate -= Time.deltaTime;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag =="Enemy")
        {
            enemyCol = other;
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag =="Enemy")
        {
           enemyCol = other;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        enemyCol = null;
    }

    private void fireProjectile()
    {
        if (enemyCol != null)
        {
            RotateTowardsEnemy();
            GameObject projectile = Instantiate(Prefab, transform.position, Quaternion.identity) as GameObject;
            projectile.GetComponent<Rigidbody2D>().AddForce(transform.right * Speed);
        }

        
    }
    private void RotateTowardsEnemy()
    {
        Vector3 dir = enemyCol.gameObject.transform.position - transform.position;
        float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
