using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioSource sword, coin, banana, jump, jump2, jump3, backgroundMusic, hit, hitplayer, 
                        fireball, backgroundMusicNight, backgroundMusicBoss, gameOver, deathEnemy, 
                         bossDeath, levelComplete, saveGame, switcher, fallBridge, pirateVoice, ghost;

    public static AudioManager instance;
    string currentDay;

    AudioSource[] audiosJump = new AudioSource[3];

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        BackgroundDayOrNight();
    }

    public void PlayAudio(AudioSource audio)
    {
        audio.Play();
    }

    public void StopAudioBackgroundMusic()
    {
        backgroundMusic.Stop();
        backgroundMusicNight.Stop();
        backgroundMusicBoss.Stop();
    }

    public void BackgroundDayOrNight()
    {
        currentDay = PlayerPrefs.GetString("currentDay", currentDay);

        if (currentDay == "night")
        {
            backgroundMusicNight.Play();
        }
        else
        {
            backgroundMusic.Play();
        }
    }


    public void RandomJump()
    {
        audiosJump[0] = jump;
        audiosJump[1] = jump2;
        audiosJump[2] = jump3;

        var randomJump = Random.Range(0, audiosJump.Length);

        PlayAudio(audiosJump[randomJump]);

    }
}
