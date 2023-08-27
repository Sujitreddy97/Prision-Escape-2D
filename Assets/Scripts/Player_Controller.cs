using UnityEngine;
using TMPro;

public class Player_Controller : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;
    [SerializeField] private Pause_Game_Controller pauseMenu;
    [SerializeField] private GameObject GameOver;
    [SerializeField] private TMP_Text livesText;

    private float lastX, lastY;
    private int lives = 3;
    private Vector3 RespawnPoint;
    private bool isPaused;
    
    private void Awake()
    {
        GameOver.SetActive(false);
    }

    private void Start()
    {
        setRespawnPoint(transform.position);
        UpdateLivesText();
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
        PauseMenuUI();
    }

    private void PauseMenuUI()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                pauseMenu.PauseGame();
            }
            else
            {
                pauseMenu.ResumeGame();
            }
        }

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

    public void DecreaseLife()
    {
        lives--;
        if (lives <= 0)
        {
            //Debug.Log("Busted");
            GameOver.SetActive(true);
            this.enabled = false;
        }
        else
        {
            transform.position = RespawnPoint;
        }
        //Debug.Log("Lives" + lives);
        UpdateLivesText();

    }
    private void UpdateLivesText()
    {
        livesText.text = "LIVES: " + lives;
    }
    public void setRespawnPoint(Vector3 position)
    {
        RespawnPoint = position;
    }

    
}
