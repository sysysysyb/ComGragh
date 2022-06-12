using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal1B : MonoBehaviour
{
    public GameObject cam;
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.transform.position = new Vector2(4.41f, -0.57f);

            cam.transform.position = new Vector3(0, 1.01f, -10f);
        }
    }
}
