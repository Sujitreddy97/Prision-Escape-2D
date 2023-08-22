using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;
    private float lastX, lastY;
    Vector2 move;


    private void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);
    }

    private void PlayerInput()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");
        if (move.x != 0)
        {
            move.y = 0;
        }
        else if (move.y != 0)
        {
            move.x = 0;
        }
        PlayerAnimation(move.x, move.y);
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
