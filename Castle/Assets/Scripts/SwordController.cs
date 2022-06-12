using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    public int swordSpeed = 4;
    Vector2 direction = Vector2.zero;
    public int positionNum = 0;    // 0:left 1:right
    public int attackPower = 2;

    void Start()
    {
        
    }

    void Update()
    {
        StartCoroutine("Attack");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Attack()
    {
        if (positionNum == 0)
        {
            direction = Vector2.left;
        }
        else
        {
            direction = Vector2.right;
        }

        transform.Translate(direction * swordSpeed * Time.deltaTime);

        yield return new WaitForSeconds(3.0f);

        Destroy(gameObject);
    }
}
