using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player_Controller player_Controller = collision.gameObject.GetComponent<Player_Controller>();
        if(player_Controller!=null)
        {
            player_Controller.setRespawnPoint(transform.position);
        }
    }
}
