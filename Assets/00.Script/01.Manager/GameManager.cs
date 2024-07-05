// # System
using System.Collections;
using System.Collections.Generic;
using TMPro;

// # Unity
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Money")]
    public float money;
    public float maxMoney;
    public float workSpeed;
    public float curWorkSpeed;
    private int textmoney;

    [Header("TMP")]
    [SerializeField] TextMeshProUGUI menoyText;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        textmoney = (int)money;
        menoyText.text = textmoney.ToString() + " / " + maxMoney.ToString();
        if (money >= maxMoney)
        {
            money = maxMoney;
        }
    }

    private void LateUpdate()
    {
        if (curWorkSpeed <= 0 && money < maxMoney)
        {
            money++;
            curWorkSpeed = workSpeed;
        }
        else
        {
            curWorkSpeed -= Time.deltaTime;
        }
    }
}
