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
    [SerializeField] private float curWork;
    private int textmoney;


    [Header("TMP")]
    [SerializeField] TextMeshProUGUI menoyText;

    private void Update()
    {
        if (curWork <= 0)
        {
            money++;
            curWork = workSpeed;
            textmoney = (int)money;
            menoyText.text = textmoney.ToString() + " / " + maxMoney.ToString();
        }
        else
        {
            curWork -= Time.deltaTime;
        }
    }
}
