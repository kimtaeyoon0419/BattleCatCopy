// # System
using System.Collections;
using System.Collections.Generic;

// # Unity
using UnityEngine;

public class DefualtCharacterAttack1 : MonoBehaviour
{
    [Header("컴포넌트")]
    private Character1 stat;
    private Animator anim;

    [Header("애니메이션")]
    private readonly int hashAttack = Animator.StringToHash("Attack");

    [Header("스탯")]
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
        Physics2D.OverlapBox(attackPos.position, new Vector2(1f, 1f), 0, stat.enemyMask)?.GetComponent<Character>()?.TakeDamage(/*공격력을 적어주세요*/0) ;
        Physics2D.OverlapBox(attackPos.position, new Vector2(1f, 1f), 0, stat.enemyMask)?.GetComponent<Tower>()?.TakeDamage(/*공격력을 적어주세요*/ 0);
        isAttack = false;
    }
}
