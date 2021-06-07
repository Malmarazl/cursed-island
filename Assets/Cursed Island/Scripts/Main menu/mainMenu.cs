using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public AudioSource MusicMenu;

    private void Start()
    {
        Time.timeScale = 1;
        if(MusicMenu != null) MusicMenu.Play();
    }
    public void openLevel(string nameLevel)
    {
        SceneManager.LoadScene(nameLevel);
    }

    public void newGame(string nameLevel)
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(nameLevel);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
