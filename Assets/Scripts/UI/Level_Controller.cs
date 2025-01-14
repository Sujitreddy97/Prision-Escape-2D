using UnityEngine;

public class Level_Controller : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player_Controller player_Controller = collision.gameObject.GetComponent<Player_Controller>();

        if (player_Controller != null)
        {
            player_Controller.setLevelComplete();
            Audio_Manager.Instance.PlaySFX(AudioName.LevelComplete);
        }
    }
}
