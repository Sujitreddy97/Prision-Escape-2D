using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Game_Controller : MonoBehaviour
{
    public void PauseGame()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
        Audio_Manager.Instance.PlaySFX(AudioName.ButtonClick);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
        Audio_Manager.Instance.PlaySFX(AudioName.ButtonClick);
    }

    public void Menu()
    {
        Time.timeScale = 1;
        Debug.Log("Main Menu");
        SceneManager.LoadScene(0);
        Audio_Manager.Instance.PlaySFX(AudioName.ButtonClick);
    }

}
