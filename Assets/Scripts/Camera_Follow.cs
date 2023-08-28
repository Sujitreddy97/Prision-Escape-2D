using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    [SerializeField] private Transform player;

    private void LateUpdate()
    {

        Vector3 cameraPos = new Vector3(player.position.x, player.position.y + 2, player.position.z - 10);
        transform.position = cameraPos;
    }

}
