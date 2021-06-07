using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_menu : MonoBehaviour
{
    public GameObject pauseMenu;
    bool isPause;


    void Awake()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        isPause = false;
    }

    public void Pause()
    {
        if (!isPause) {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            isPause = true;
            AudioManager.instance.StopAudioBackgroundMusic();
        }
    }

    public void Continue()
    {
        if (isPause)
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            isPause = false;
            AudioManager.instance.BackgroundDayOrNight();
        }
    }

    public void ExitGame(string nameLevel)
    {
        SceneManager.LoadScene(nameLevel);
    }
}
