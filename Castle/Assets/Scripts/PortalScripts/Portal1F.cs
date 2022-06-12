using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal1F : MonoBehaviour
{
    public GameObject cam;
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.transform.position = new Vector2(14.57f, 3.48f);

            cam.transform.position = new Vector3(10.65f, 1.01f, -10f);
        }
    }
}
