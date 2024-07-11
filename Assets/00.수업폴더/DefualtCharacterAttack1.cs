// # System
using System.Collections;
using System.Collections.Generic;

// # Unity
using UnityEngine;

public class DefualtCharacterAttack1 : MonoBehaviour
{
    [Header("������Ʈ")]
    private Character1 stat;
    private Animator anim;

    [Header("�ִϸ��̼�")]
    private readonly int hashAttack = Animator.StringToHash("Attack");

    [Header("����")]
    private bool isAttack;
    [SerializeField] private Transform attackPos;

    private void Awake()
    {
        stat = GetComponent<Character1>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (stat.CheckEnemy() && stat.curAttackSpeed <= 0 && !isAttack)
        {
            isAttack = true;
            anim.SetTrigger(hashAttack);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position, new Vector2(1f, 1f));
    }

    public void AttackEvent()
    {
        stat.curAttackSpeed = stat.maxAttackSpeed;
        Physics2D.OverlapBox(attackPos.position, new Vector2(1f, 1f), 0, stat.enemyMask)?.GetComponent<Character>()?.TakeDamage(/*���ݷ��� �����ּ���*/0) ;
        Physics2D.OverlapBox(attackPos.position, new Vector2(1f, 1f), 0, stat.enemyMask)?.GetComponent<Tower>()?.TakeDamage(/*���ݷ��� �����ּ���*/ 0);
        isAttack = false;
    }
}
