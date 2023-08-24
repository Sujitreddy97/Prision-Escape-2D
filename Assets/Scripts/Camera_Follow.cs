using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private void FixedUpdate()
    {
        Vector3 cameraPos = transform.position;

        cameraPos.x = player.transform.position.x;
        cameraPos.y = player.transform.position.y;
        cameraPos.z = transform.position.z;
        transform.position = cameraPos;
    }

}
