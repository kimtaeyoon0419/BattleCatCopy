// # System
using System.Collections;
using System.Collections.Generic;

// # Unity
using UnityEngine;

public class Character1 : MonoBehaviour
{
    [Header("스탯")]
    //이동속도, 공격력, 최대체력, 현재체력
    public float attackRange;
    public float maxAttackSpeed;
    public float curAttackSpeed;
    public LayerMask enemyMask;

    [Header("몬스터인가?")]
    public bool isMonster;
    public float dieGold;

    [Header("죽었을 때 유령")]
    [SerializeField] private GameObject dieGhost;

    private void Start()
    {
        // 현재 체력을 최대 체력으로 만들어줘요!
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
        // 현재 체력에서 받은 공격력 만큼 체력을 줄여줘요!
        // 만약 현재 체력이 0보다 작다면 죽어야해요!
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
