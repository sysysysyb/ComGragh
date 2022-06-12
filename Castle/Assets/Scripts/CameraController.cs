using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraSpeed = 0;   // 카메라 속도값
    public GameObject player;       // 플레이어 오브젝트
    Vector2 direction;              // 벡터값
    Vector2 moveDir;

    void Update()
    {
        // 플레이어가 y축을 볼 때 약간 아래에 위치하도록 하기 위해
        // x와 y축을 따로 지정해줌
        direction.x = player.transform.position.x - this.transform.position.x;
        direction.y = player.transform.position.y - this.transform.position.y + 1;

        moveDir = new Vector2(direction.x * cameraSpeed * Time.deltaTime, direction.y * cameraSpeed * Time.deltaTime);

        this.transform.Translate(moveDir);
    }
}
