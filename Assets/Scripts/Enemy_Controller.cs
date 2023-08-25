using System.Collections;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    [SerializeField] private float duration;
    [SerializeField] private float rotationAngle = 90f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player_Controller playerController = collision.gameObject.GetComponent<Player_Controller>();
        if (playerController != null)
        {
            //Debug.Log("Player Died");
            //Decrease Life
            //Respwan
            playerController.DecreaseLife(1);
        }
    }

    private void Start()
    {
        StartCoroutine("EnemyRotateControl");
    }

    IEnumerator TurnAround()
    {
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = startRotation * Quaternion.Euler(0, 0, rotationAngle);
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, t);
            yield return null;
        }
        yield return new WaitForSeconds(duration);
    }

    IEnumerator EnemyRotateControl()
    {
        while (true)
        {
            yield return StartCoroutine(TurnAround());
        }
    }
}
