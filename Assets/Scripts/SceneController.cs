using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    private GameObject enemy;
    private Vector3 spawnPoint = new Vector3 (0, 0, 5);
    private int enemyCount = 5;
    private GameObject[] enemies;

    private void Start()
    {
        enemies = new GameObject[enemyCount];
        for (int i = 0; i < enemyCount; i++)
        {
            enemies[i] = Instantiate(enemyPrefab) as GameObject;
        }
    }
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            if(enemies[i] == null)
            {
                enemies[i] = Instantiate(enemyPrefab) as GameObject;
                enemies[i].transform.position = spawnPoint;
                float angle = Random.Range(0, 360);
                enemies[i].transform.Rotate(0, angle, 0);
            }
           
        }

    }
}
