using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Over_Controller : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Audio_Manager.Instance.PlaySFX(AudioName.ButtonClick);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
        Audio_Manager.Instance.PlaySFX(AudioName.ButtonClick);
    }
}
