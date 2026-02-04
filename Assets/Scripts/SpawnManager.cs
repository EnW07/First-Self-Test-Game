using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //these two objects are for rotation
    public GameObject enemyPrefab;
    public GameObject enemyBigPrefab;
    //boss object
    public GameObject bossPrefab;
    //lists for different enemy colors
    public Object[] enemyPrefabs;
    public Object[] enemyBigPrefabs;
    //min amount for certain types of enemies to spawn
    private int minForBigEnemies = 5;
    private int minForBoss = 10;

    //a variable to store a coroutine in
    Coroutine spawnEnemy;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        //we put it in start method to evoke the coroutine
        spawnEnemy = StartCoroutine(SpawnEnemies(minForBigEnemies, minForBoss));       

    }

    // Update is called once per frame
    void Update()
    {
        
    }






    //the coroutine that spawns enemies under certain conditions
    IEnumerator SpawnEnemies(int minForBigEnemies, int minForBoss)
    {
       while(ScoreManager.Instance.score < minForBigEnemies || ScoreManager.Instance.numberOfKilled < minForBigEnemies)
        {
            SpawnSmallEnemies();
            yield return new WaitForSeconds(2);

        }
        if (ScoreManager.Instance.score >= minForBigEnemies && ScoreManager.Instance.numberOfKilled >= minForBigEnemies)
        {
            while (ScoreManager.Instance.score >= minForBigEnemies && ScoreManager.Instance.score < minForBoss && ScoreManager.Instance.numberOfKilled >= minForBigEnemies && ScoreManager.Instance.numberOfKilled < minForBoss)
            {
                SpawnBigEnemies();
                yield return new WaitForSeconds(2);
            }

            if (ScoreManager.Instance.score >= minForBoss && ScoreManager.Instance.numberOfKilled >= minForBoss)
            {
                SpawnBoss();
            }
        }
    }






    //method to spawn small enemies
    void SpawnSmallEnemies()
    {
        float borderX = 10;
        float borderYMax = 3.5f;
        float borderYMin = -3.5f;
        float randomYPos = Random.Range(borderYMin, borderYMax);
        Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], new Vector3(borderX, randomYPos, 0), enemyPrefab.transform.rotation);
    }

    //method to spawn big enemies
    void SpawnBigEnemies()
    {
        float borderX = 10;
        float borderYMax = 3.5f;
        float borderYMin = -3.5f;
        float randomYPos = Random.Range(borderYMin, borderYMax);
        Instantiate(enemyBigPrefabs[Random.Range(0, enemyBigPrefabs.Length)], new Vector3(borderX, randomYPos, 0), enemyBigPrefab.transform.rotation);
    }

    //method to spawn boss
    void SpawnBoss()
    {
        float borderX = 10;
        float borderY = 0;
        Instantiate(bossPrefab, new Vector3(borderX, borderY, 0), enemyBigPrefab.transform.rotation);

    }

}
