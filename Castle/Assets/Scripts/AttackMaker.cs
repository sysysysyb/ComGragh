using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMaker : MonoBehaviour
{
    Vector2 left = Vector2.zero;
    Vector2 right = Vector2.zero;

    public GameObject sword;
    public GameObject player;

    //Transform transform;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Attack"))
        {
            StartCoroutine("Attack");
        }

        position();
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(0.4f);

        Instantiate(sword, transform.position, transform.rotation);

        yield return new WaitForSeconds(0.3f);

        Instantiate(sword, transform.position, transform.rotation);
    }

    void position()
    {
        //left = new Vector2(player.transform.position.x + 0.15f, player.transform.position.y - 0.05f);
        //right = new Vector2(player.transform.position.x - 0.15f, player.transform.position.y - 0.05f);

        if (player.GetComponent<SpriteRenderer>().flipX == true)
        {
            transform.position = new Vector2(player.transform.position.x - 0.2f, player.transform.position.y - 0.05f); ;
        }
        else
        {
            transform.position = new Vector2(player.transform.position.x + 0.2f, player.transform.position.y - 0.05f); ;
        }
    }
}
