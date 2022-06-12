using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal1A : MonoBehaviour
{
    public GameObject cam;
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("플");
            player.transform.position = new Vector2(6.3f, -0.57f);

            cam.transform.position = new Vector3(10.65f, 1.01f, -10f);
        }
    }
}
