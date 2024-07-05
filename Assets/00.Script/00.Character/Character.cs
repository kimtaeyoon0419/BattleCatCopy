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

    [Header("DieGhost")]
    [SerializeField] private GameObject dieGhost;

    private void Update()
    {
        if(curAttackSpeed > 0)
        {
            curAttackSpeed -= Time.deltaTime;
        }

        if(curHp <= 0)
        {
            Instantiate(dieGhost, transform.position, Quaternion.identity);
        }
    }

    public bool CheckEnemy()
    {
        Debug.DrawRay(transform.position, Vector2.left * attackRange, Color.red);
        return Physics2D.Raycast(transform.position, Vector2.left, attackRange, enemyMask);
    }
}
