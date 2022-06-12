using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal1J : MonoBehaviour
{
    public GameObject cam;
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.transform.position = new Vector2(17f, 5.43f);

            cam.transform.position = new Vector3(21.31f, 6.97f, -10f);
        }
    }
}
