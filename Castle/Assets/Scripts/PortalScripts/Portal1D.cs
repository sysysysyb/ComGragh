using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal1D : MonoBehaviour
{
    public GameObject cam;
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.transform.position = new Vector2(15.22f, -0.57f);

            cam.transform.position = new Vector3(10.65f, 1.01f, -10f);
        }
    }
}
