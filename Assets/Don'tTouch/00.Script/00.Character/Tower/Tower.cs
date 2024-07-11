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

    private Animator aniamtor;

    [Header("���� �¸�")]
    [SerializeField] private GameObject winText;

    private void Awake()
    {
        aniamtor = GetComponent<Animator>();
    }

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
        aniamtor.SetTrigger("Damage");
        if (curHp <= 0)
        {
            curHp = 0;
            winText.SetActive(true);
        }
    }
}
