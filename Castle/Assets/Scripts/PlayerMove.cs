using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Vector2 direction;          // 플레이어가 움직이는 벡터값
    public float speed;         // 값
    float horizontal;           // 좌우 방향값
    bool isJumping = false;     // 점프중인지 아닌지 판단하는 값
    public float jumpPower;     // 점프 크기 값
    bool isAttacking;           //  공격중인지 아닌지 판단하는 값
    public GameObject cam;
    public int attackPower;
    public GameObject swordMaker;
    public int hp = 10;
    public GameObject sword;

    Vector2 right = new Vector2(-0.05f, -0.04f);
    Vector2 left = new Vector2(0.05f, -0.04f);

    Animator animator;
    SpriteRenderer rend;
    Rigidbody2D rigid;
    CapsuleCollider2D col;

    void Start()
    {
        animator = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        col = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        Move();
        Jump();
        Attack();
    }

    // 기본 움직임
    void Move()
    {
        // 좌우 방향값을 구하고 벡터값으로 바꿔줌
        horizontal = Input.GetAxisRaw("Horizontal");
        direction = horizontal * Vector2.right;

        // 좌우 방향값이 0이 아니면 Move 애니메이션 실행
        // 상황에 맞게 좌우 반전
        if (horizontal != 0)
        {
            animator.SetBool("isMoving", true);

            if (horizontal > 0)
            {
                rend.flipX = false;
                col.offset = right;
                sword.GetComponent<SwordController>().positionNum = 1;
            }
            else
            {
                rend.flipX = true;
                col.offset = left;
                sword.GetComponent<SwordController>().positionNum = 0;
            }
        }
        else animator.SetBool("isMoving", false);

        // 벡터값, 속도값을 받아 움직임
        transform.Translate(direction * speed * Time.deltaTime);
    }

    // 바닥에 닿아있으면 점프중이 아니라고 알림
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Wood"))
        {
            animator.SetBool("isJumping", false);

            isJumping = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine("Hurt");
        }
    }

    // 막다른길에 다다르면 카메라컨트롤러 스크립트를 비활성화하여
    // 카메라가 플레이어를 더이상 따라가지 않게 함
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DeadEnd"))
        {
            cam.GetComponent<CameraController>().enabled = false;
        }

        // 왜 안되는지 모르겠음 //
        /*
        if (other.gameObject.CompareTag("Wood"))
        {
            //Debug.Log("wood");
            if (GetComponent<Rigidbody2D>().velocity.y > 0)
            {
                other.GetComponent<BoxCollider2D>().isTrigger = true;
            }
        }
        */
    }

    // 막다른길에서 벗어나면 다시 카메라컨트롤러 스크립트를 활성화하여
    // 카메라가 플레이어를 따라오게 함
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DeadEnd"))
        {
            cam.GetComponent<CameraController>().enabled = true;
        }

        if (other.gameObject.CompareTag("Wood"))
        {
            other.GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }

    void Jump()
    {
        // z 버튼을 누르면 점프함
        if (Input.GetButtonDown("Jump"))
        {
            if (isJumping == true) // 점프중이라면 그냥 리턴함
            {
                return;
            }

            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);

            animator.SetBool("isJumping", true);

            isJumping = true;
        }
    }

    // 공격 애니메이션이 한번 재생되면 끝날때까지(1초간) 기다림
    IEnumerator WaitForAttack()
    {
        yield return new WaitForSeconds(1.0f);
        isAttacking = false;
    }

    void Attack()
    {
        if (Input.GetButtonDown("Attack"))
        {
            if (isAttacking == false)
            {
                animator.SetTrigger("isAttacking");
                isAttacking = true;
                //sword.GetComponent<PolygonCollider2D>().enabled = true;

                StartCoroutine("WaitForAttack");
            }
            else return;    // 공격중이라면 그냥 리턴함
        }
    }

    IEnumerator Hurt()
    {
        animator.SetTrigger("isHurt");
        hp -= 5;
        rend.color = new Color(rend.color.r, rend.color.g, rend.color.b, 0.5f);

        yield return new WaitForSeconds(2.0f);

        rend.color = new Color(rend.color.r, rend.color.g, rend.color.b, 1f);
    }
}
