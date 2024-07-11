// # System
using System.Collections;
using System.Collections.Generic;

// # Unity
using UnityEngine;

public class DefualtCharacterMove1 : MonoBehaviour
{
    [Header("������Ʈ")]
    private Rigidbody2D rb;
    private Animator animator;
    private Character1 stat;

    [Header("�ִϸ��̼�")]
    private readonly int hashMove = Animator.StringToHash("Move");

    [Header("����")]
    private bool isMoving;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        stat = GetComponent<Character1>();
    }

    private void Update()
    {
        Move();
    }

    protected void Move()
    {
        if (!stat.CheckEnemy())
        {
            //���ӵ��� �������� �̵��ӵ���ŭ �ּ���!

            if (isMoving != true)
            {
                isMoving = !isMoving;
                animator.SetBool(hashMove, isMoving);
            }
        }
        else
        {
            rb.velocity = Vector3.zero;
            if(isMoving == true)
            {
                isMoving = !isMoving;
                animator.SetBool(hashMove, isMoving);
            }
        }
    }
}
