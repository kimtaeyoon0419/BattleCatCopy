// # System
using System.Collections;
using System.Collections.Generic;

// # Unity
using UnityEngine;

public class Character1 : MonoBehaviour
{
    [Header("����")]
    //�̵��ӵ�, ���ݷ�, �ִ�ü��, ����ü��
    public float attackRange;
    public float maxAttackSpeed;
    public float curAttackSpeed;
    public LayerMask enemyMask;

    [Header("�����ΰ�?")]
    public bool isMonster;
    public float dieGold;

    [Header("�׾��� �� ����")]
    [SerializeField] private GameObject dieGhost;

    private void Start()
    {
        // ���� ü���� �ִ� ü������ ��������!
    }

    private void Update()
    {
        if(curAttackSpeed > 0)
        {
            curAttackSpeed -= Time.deltaTime;
        }
    }

    public bool CheckEnemy()
    {
        Debug.DrawRay(transform.position, Vector2.left * attackRange, Color.red);
        return Physics2D.Raycast(transform.position, Vector2.left, attackRange, enemyMask);
    }

    public void TakeDamage(float damage)
    {
        // ���� ü�¿��� ���� ���ݷ� ��ŭ ü���� �ٿ����!
        // ���� ���� ü���� 0���� �۴ٸ� �׾���ؿ�!
    }

    private void Die()
    {
        Instantiate(dieGhost, transform.position, Quaternion.identity);
        if (isMonster)
        {
            GameManager.instance.money += dieGold;
        }
        Destroy(gameObject);
    }
}
