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
    public GameObject catObj;
}

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;

    [Header("스폰 고양이")]
    public List<Cat> cats;
    [SerializeField] private Transform spawnPos;

    private void Awake()
    {
        instance = this;
    }

    public void SpawnCatBtn(int index)
    {
        if (cats[index].cost <= GameManager.instance.money)
        {
            GameManager.instance.money -= cats[index].cost;
            Instantiate(cats[index].catObj, spawnPos.position, Quaternion.identity);
        }
    }
}
