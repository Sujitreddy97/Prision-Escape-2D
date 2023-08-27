using UnityEngine;
using UnityEngine.SceneManagement;

public class Lobby_Manager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        Audio_Manager.Instance.PlaySFX(AudioName.ButtonClick);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        Audio_Manager.Instance.PlaySFX(AudioName.ButtonClick);
    }
}
