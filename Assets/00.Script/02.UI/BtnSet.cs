// # System
using System.Collections;
using System.Collections.Generic;
using TMPro;

// # Unity
using UnityEngine;

public class BtnSet : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;

    private void Awake()
    {
        textMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        textMeshProUGUI.text = SpawnManager.instance.cats[0].cost.ToString();
    }
}
