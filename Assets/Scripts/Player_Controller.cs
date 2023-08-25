using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;
    private float lastX, lastY;
    private int lives = 3;
    private Vector3 RespawnPoint;

    private void Start()
    {
        setRespawnPoint(transform.position);
    }
    private void Update()
    {
        PlayerInput();
    }

    private void PlayerInput()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        if (horizontal != 0)
        {
            vertical = 0;
        }
        else if (vertical != 0)
        {
            horizontal = 0;
        }
        PlayerAnimation(horizontal, vertical);
        PlayerMovement(horizontal, vertical);
    }
    private void PlayerMovement(float horizontal, float vertical)
    {
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        position.y += vertical * speed * Time.deltaTime;
        transform.position = position;
    }

    private void PlayerAnimation(float horizontal, float vertical)
    {

        if (horizontal == 0 && vertical == 0)
        {
            anim.SetFloat("LastDirX", lastX);
            anim.SetFloat("LastDirY", lastY);
            anim.SetBool("Movement", false);
        }
        else
        {
            lastX = horizontal;
            lastY = vertical;
            anim.SetBool("Movement", true);
        }

        Vector3 scale = transform.localScale;
        if (horizontal > 0)
        {
            scale.x = -1 * scale.x;
        }
        else if (horizontal < 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        anim.SetFloat("DirX", horizontal);
        anim.SetFloat("DirY", vertical);

    }

    public void DecreaseLife(int life)
    {
        if (lives > 0)
        {
            transform.position = RespawnPoint;
            lives -= life;
            Debug.Log("Lives" + lives);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("Busted");
        }
            
    }

    public void setRespawnPoint(Vector3 position)
    {
        RespawnPoint = position;
    }

}
