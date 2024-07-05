// # System
using System.Collections;
using System.Collections.Generic;
using TMPro;

// # Unity
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Money")]
    [SerializeField] private float money;
    [SerializeField] private float maxMoney;
    [SerializeField] private float workSpeed;
    private int textmoney;


    [Header("TMP")]
    [SerializeField] TextMeshProUGUI menoyText;

    private void Update()
    {
        if (workSpeed <= 0 && money <= maxMoney)
        {
            money++;
            if(money > maxMoney)
            {
                money = maxMoney;
            }
            textmoney = (int)money;
            menoyText.text = textmoney.ToString() + " / " + maxMoney.ToString();
        }
        else
        {
            workSpeed -= Time.deltaTime;
        }
    }
}
