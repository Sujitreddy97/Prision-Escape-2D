using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;
    private float lastX, lastY;



    private void Update()
    {
        PlayerInput();
    }

    /* private void FixedUpdate()
     {
         rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);
     }*/

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

}
