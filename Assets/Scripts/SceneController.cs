using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private GameObject iguanaPrefab;
    [SerializeField]
    private Transform iguanaSpawnPt;
    private GameObject enemy;
    private Vector3 enemySpawnPoint = new Vector3 (0, 0, 5);
    private int enemyCount = 5;
    private int iguanaCount = 10;
    private GameObject[] enemies;
    private GameObject[] iguanas;
    private void Start()
    {
        enemies = new GameObject[enemyCount];
        for (int i = 0; i < enemyCount; i++)
        {
            enemies[i] = Instantiate(enemyPrefab) as GameObject;
            enemies[i].transform.position = enemySpawnPoint;
            float angle = Random.Range(0, 360);
            enemies[i].transform.Rotate(0, angle, 0);
        }
        iguanas = new GameObject[iguanaCount];
        for (int i = 0; i < iguanaCount; i++)
        {
            iguanas[i] = Instantiate(iguanaPrefab) as GameObject;
            iguanas[i].transform.position = iguanaSpawnPt.position;
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
                enemies[i].transform.position = enemySpawnPoint;
                float angle = Random.Range(0, 360);
                enemies[i].transform.Rotate(0, angle, 0);
            }
           
        }

    }
}
