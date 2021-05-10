using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1;
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
