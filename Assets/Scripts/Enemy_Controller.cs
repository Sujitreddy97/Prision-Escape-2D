using System.Collections;
using UnityEngine;

public enum EnemyType
{
    Type1,
    Type2,
    Type3
}

public class Enemy_Controller : MonoBehaviour
{
    [SerializeField] private float duration;
    [SerializeField] private float rotationAngle = 90f;
    [SerializeField] private EnemyType enemyType;
    [SerializeField] private float speed;
    private bool isMovingRight;
    private bool isMovingUp;
    private void Start()
    {
        if (enemyType == EnemyType.Type1)
        {
            StartCoroutine("EnemyRotateControl");
        }
    }
    void Update()
    {
        if (enemyType == EnemyType.Type2 || enemyType == EnemyType.Type3)
            Patrol(enemyType);
    }

    void Patrol(EnemyType type)
    {
        switch (type)
        {
            case EnemyType.Type2:
                transform.Translate(Vector2.right * (isMovingRight ? 1 : -1) * speed * Time.deltaTime);
                break;

            case EnemyType.Type3:
                transform.Translate(Vector2.up * (isMovingUp ? 1 : -1) * speed * Time.deltaTime);
                break;
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player_Controller playerController = collision.gameObject.GetComponent<Player_Controller>();
        if (playerController != null)
        {
            playerController.DecreaseLife();
        }

        if (collision.gameObject.tag == "Wall")
        {
            isMovingRight = !isMovingRight;
            isMovingUp = !isMovingUp;
        }
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
