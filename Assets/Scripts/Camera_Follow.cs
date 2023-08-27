using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    [SerializeField] private Transform player;

    private void LateUpdate()
    {

        Vector3 cameraPos = new Vector3(player.position.x, player.position.y, player.position.z) + new Vector3(2.5f, 2f, -10f);
        transform.position = cameraPos;
    }

}
