using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Game_Controller : MonoBehaviour
{
    public void PauseGame()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void Menu()
    {
        Time.timeScale = 1;
        Debug.Log("Main Menu");
        SceneManager.LoadScene(0);
    }

}
