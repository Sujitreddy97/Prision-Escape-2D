using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private GameObject checkPoint_Text;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player_Controller player_Controller = collision.gameObject.GetComponent<Player_Controller>();
        if(player_Controller!=null)
        {
            player_Controller.setRespawnPoint(transform.position);
            checkPoint_Text.SetActive(true);
            Audio_Manager.Instance.PlaySFX(AudioName.CheckPoint);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Player_Controller player_Controller = collision.gameObject.GetComponent<Player_Controller>();
        if (player_Controller != null)
        {
            checkPoint_Text.SetActive(false);
        }
    }
}
