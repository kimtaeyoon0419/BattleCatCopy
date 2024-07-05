using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("����")]
    [SerializeField] private float maxHp;
    [SerializeField] private float curHp;
    private int textHp;

    [Header("�ؽ�Ʈ")]
    [SerializeField] private TextMeshProUGUI tmp;

    private void Start()
    {
        curHp = maxHp;
    }

    private void Update()
    {
        textHp = (int)curHp;
        tmp.text = textHp.ToString() + "/" + maxHp.ToString();
    }

    public void TakeDamage(float damage)
    {
        curHp -= damage;
        if (curHp <= 0)
        {
           
        }
    }
}
