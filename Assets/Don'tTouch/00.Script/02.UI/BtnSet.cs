// # System
using System.Collections;
using System.Collections.Generic;
using TMPro;

// # Unity
using UnityEngine;
using UnityEngine.UI;

public class BtnSet : MonoBehaviour
{
    [Header("TMP")]
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;

    [Header("Slider")]
    [SerializeField] private Slider cooldownBar;

    [Header("BtnIndex")]
    [SerializeField] private int btnIndex;

    [Header("BtnChar")]
    [SerializeField] private Cat btnCat;

    private void Awake()
    {
        textMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>();
        cooldownBar = GetComponentInChildren<Slider>();
    }

    private void Start()
    {
        btnCat = SpawnManager.instance.cats[btnIndex];
        textMeshProUGUI.text = btnCat.cost.ToString();
    }

    private void LateUpdate()
    {
        if (SpawnManager.instance.cats[btnIndex].curSpawnCoolTime > 0)
        {
            cooldownBar.gameObject.SetActive(true);
            textMeshProUGUI.gameObject.SetActive(false);
            cooldownBar.value = btnCat.curSpawnCoolTime / btnCat.spawnCoolTime;
        }
        else
        {
            textMeshProUGUI.gameObject.SetActive(true);
            cooldownBar.gameObject.SetActive(false);
        }
    }
}
