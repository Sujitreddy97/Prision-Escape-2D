using UnityEngine;

public class Enemy_Patrol : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool isMovingRight;

    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        if(isMovingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else if(!isMovingRight)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            isMovingRight = !isMovingRight;
        }
    }
    
}
