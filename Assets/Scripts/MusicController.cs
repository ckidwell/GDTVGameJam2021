using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    GameController gamecontroller;

    [SerializeField] AudioSource audiosource;
    //[SerializeField] AudioSource policeChatter;
    
    [SerializeField] float timeRemaining = 120;
    [SerializeField] float timeToStartWorriedClip = 60;
    [SerializeField] float timeToStartStressedClip = 10;
    bool timerIsRunning = false;

    [SerializeField] AudioClip calmMusic;
    [SerializeField] AudioClip worriedMusic;
    [SerializeField] AudioClip stressedMusic;
    [SerializeField] AudioClip policeChatter;

    bool playCalm = true;
    bool playWorried = false;
    bool playStressed = false;

    bool playChatter = true;

    private void Awake()
    {
        int numMusicPlayers = FindObjectsOfType<MusicController>().Length;

        if (numMusicPlayers > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gamecontroller = FindObjectOfType<GameController>();
    }

    public void StartTimer()
    {
        timerIsRunning = true;
        if (playChatter)
        {
            audiosource.PlayOneShot(policeChatter);
            playChatter = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                if (timeRemaining < timeToStartWorriedClip && timeRemaining > timeToStartStressedClip)
                {
                    if (playCalm == true)
                    {
                        playCalm = false;
                        playWorried = true;
                        AssignNewClip(worriedMusic);
                    }
                }
                if (timeRemaining < timeToStartStressedClip)
                {
                    if (playWorried == true)
                    {
                        playWorried = false;
                        playStressed = true;
                        AssignNewClip(stressedMusic);
                    }
                }
            }
            else
            {
                gamecontroller.GameOver();
            }
        }
    }

    void AssignNewClip(AudioClip newClip)
    {
        audiosource.clip = newClip;
        audiosource.Play();
    }
}
