// # System
using System.Collections;
using System.Collections.Generic;

// # Unity
using UnityEngine;

public class DefualtCharacterMove1 : MonoBehaviour
{
    [Header("컴포넌트")]
    private Rigidbody2D rb;
    private Animator animator;
    private Character1 stat;

    [Header("애니메이션")]
    private readonly int hashMove = Animator.StringToHash("Move");

    [Header("스탯")]
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
            //가속도를 왼쪽으로 이동속도만큼 주세요!

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
