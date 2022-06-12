using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal1G : MonoBehaviour
{
    public GameObject cam;
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.transform.position = new Vector2(6.39f, 5.43f);

            cam.transform.position = new Vector3(10.65f, 6.97f, -10f);
        }
    }
}
