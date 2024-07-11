// # System
using System.Collections;
using System.Collections.Generic;

// # Unity
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("스탯")]
    public float speed;
    public float attackPower;
    public float attackRange;
    public float maxAttackSpeed;
    public float curAttackSpeed;
    public float maxHp;
    public float curHp;
    public LayerMask enemyMask;

    [Header("몬스터인가?")]
    public bool isMonster;
    public float dieGold;

    [Header("죽었을 때 유령")]
    [SerializeField] private GameObject dieGhost;

    private void Start()
    {
        curHp = maxHp;
        if(isMonster)
        {
            speed *= -1;
            attackRange *= -1;
        }
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
        curHp -= damage;
        if(curHp <= 0)
        {
            Die();
        }
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
