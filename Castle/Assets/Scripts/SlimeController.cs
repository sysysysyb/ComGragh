using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour
{
    Vector2 direction;          // 슬라임이 움직이는 벡터값
    public float speed = 1;     // 이동값
    int moveNum = 0;            // 0:Idle, 1:Left, 2:Right
    public int hp = 10;

    Animator animator;
    SpriteRenderer rend;

    void Start()
    {
        animator = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();

        StartCoroutine("MoveCoroutine");
    }

    void Update()
    {
        Move();
        Die();
    }

    void Move()
    {
        // 움직일 방향을 정할 벡터값을 구함
        direction = Vector2.zero;

        // 좌우 방향값이 0보다 크면 Move 애니메이션 실행
        // 상황에 맞게 좌우 반전
        if (moveNum > 0)
        {
            // 1이면 왼쪽으로 이동
            if (moveNum == 1)
            {
                direction = Vector2.left;
                rend.flipX = true;
            }
            // 2이면 오른쪽으로 이동
            else
            {
                direction = Vector2.right;
                rend.flipX = false;
            }
        }

        // 벡터값, 이동값을 받아 움직임
        transform.Translate(direction * speed * Time.deltaTime);
    }

    // 벽과 닿으면 반대쪽으로 돌아감
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Obstacle"))
        {
            if (rend.flipX == true)
            {
                moveNum = 2;
            }
            else
            {
                moveNum = 1;
            }
        }

        // 공격에 맞으면 체력이 닳음
        if (collider.gameObject.CompareTag("Sword"))
        {
            Hit();
            hp -= collider.GetComponent<SwordController>().attackPower; // 수정
            //Debug.Log(hp);
        }
    }

    // 2초마다 한번씩 움직임 제어
    IEnumerator MoveCoroutine()
    {
        moveNum = Random.Range(0, 3);

        if (moveNum > 0)
            animator.SetBool("isMoving", true);
        else 
            animator.SetBool("isMoving", false);

        yield return new WaitForSeconds(2f);

        StartCoroutine("MoveCoroutine");
    }

    void Hit()
    {
        animator.SetTrigger("Hit");
    }

    void Die()
    {
        if (hp <= 0)
        {
            animator.SetTrigger("Die");
            Destroy(gameObject, 1f);
        }
    }
}
