using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal1C : MonoBehaviour
{
    public GameObject cam;
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.transform.position = new Vector2(16.9f, -0.57f);

            cam.transform.position = new Vector3(21.3f, 1.01f, -10f);
        }
    }
}
