using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Spawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public GameObject enemy;
        public int count;
        public float rate;
    }

    public enum SpawnState { SPAWNING, WAITING, COUNTING};

    public Wave[] waves;
    private int next = 0;
    public float timeBetween = 5f;
    public float waveCountDown;
    public float spawnRate;
    public SpawnState state;
    private float searchCount = 1f;

    void Start()
    {
        waveCountDown = timeBetween;
    }

    void Update()
    {
        if(state == SpawnState.WAITING)
        {
            if(!EnemyAlive())
            {
                NextWave();
            }
            else return;
        }

        if (waveCountDown <= 0)
        {
            if(state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[next]));
            }

        }
        else
        {
            waveCountDown -= Time.deltaTime;
        }

        int wavesInt = (int)Mathf.Ceil(waveCountDown);
    }

    void NextWave()
    {
        state = SpawnState.COUNTING;
        waveCountDown = timeBetween;

        if (next + 1 > waves.Length - 1)
        {
            return;
        }
        else next++;
    }

    bool EnemyAlive()
    {
        searchCount -= Time.deltaTime;
        if (searchCount <= 0f)
        {
            searchCount = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave (Wave wave)
    {
        state = SpawnState.SPAWNING;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(spawnRate / wave.rate);
        }

        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, transform.position, transform.rotation);
    }
}
