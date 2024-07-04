// # System
using System.Collections;
using System.Collections.Generic;

// # Unity
using UnityEngine;

public class DefualtCatAttack : MonoBehaviour
{
    [Header("컴포넌트")]
    private Character stat;
    private Animator anim;

    [Header("애니메이션")]
    private readonly int hashAttack = Animator.StringToHash("Attack");

    [Header("스탯")]
    private bool isAttack;

    private void Awake()
    {
        stat = GetComponent<Character>();
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

    public void AttackEvent()
    {
        stat.curAttackSpeed = stat.maxAttackSpeed;
        isAttack = false;
    }
}
