// # System
using System.Collections;
using System.Collections.Generic;

// # Unity
using UnityEngine;

public class DefualtCatAttack : MonoBehaviour
{
    [Header("������Ʈ")]
    private Character stat;
    private Animator anim;

    [Header("�ִϸ��̼�")]
    private readonly int hashAttack = Animator.StringToHash("Attack");

    [Header("����")]
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
