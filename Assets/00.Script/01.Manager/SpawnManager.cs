// # System
using System;
using System.Collections;
using System.Collections.Generic;

// # Unity
using UnityEngine;

[Serializable]
public class Cat
{
    public string catName;
    public float cost;
    public float spawnCoolTime;
    public float curSpawnCoolTime;
    public GameObject catObj;
}

[Serializable]
public class Enemy
{
    public string enemyName;
    public GameObject enemyObj;
}

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;

    [Header("스폰 고양이")]
    public List<Cat> cats;
    [SerializeField] private Transform spawnPos;

    [Header("스폰 적")]
    public List<Enemy> enemies;
    [SerializeField] private Transform enemySpawnPos;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartCoroutine(Co_EnemySpawner());
    }

    private void Update()
    {
        for (int i = 0; i < cats.Count; i++)
        {
            if(cats[i].curSpawnCoolTime >= 0)
            {
                cats[i].curSpawnCoolTime -= Time.deltaTime;
            }
        }
    }

    public void SpawnCatBtn(int index)
    {
        if (cats[index].cost <= GameManager.instance.money && cats[index].curSpawnCoolTime <= 0)
        {
            GameManager.instance.money -= cats[index].cost;
            cats[index].curSpawnCoolTime = cats[index].spawnCoolTime;
            Instantiate(cats[index].catObj, spawnPos.position, Quaternion.identity);
        }
    }

    IEnumerator Co_EnemySpawner()
    {
        float respawnTime = UnityEngine.Random.Range(3f, 5f);
        Instantiate(enemies[0].enemyObj, enemySpawnPos.position, Quaternion.identity);
        yield return new WaitForSeconds(respawnTime);
        StartCoroutine(Co_EnemySpawner());
    }
}
