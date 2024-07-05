// # System
using System.Collections;
using System.Collections.Generic;

// # Unity
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("½ºÅÈ")]
    public float speed;
    public float attackPower;
    public float attackRange;
    public float maxAttackSpeed;
    public float curAttackSpeed;
    public float maxHp;
    public float curHp;
    public bool isMonster;
    public LayerMask enemyMask;

    private void Start()
    {
        curHp = maxHp;
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

    }
}
