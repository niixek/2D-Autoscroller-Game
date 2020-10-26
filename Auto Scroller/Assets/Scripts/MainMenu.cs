using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(int i)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + i);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
