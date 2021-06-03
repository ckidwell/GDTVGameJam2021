using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    AudioSource audiosource;
    
    [SerializeField] float timeRemaining = 120;
    [SerializeField] float timeToStartWorriedClip = 60;
    [SerializeField] float timeToStartStressedClip = 10;
    bool timerIsRunning = false;

    [SerializeField] AudioClip calmMusic;
    [SerializeField] AudioClip worriedMusic;
    [SerializeField] AudioClip stressedMusic;

    bool playCalm = true;
    bool playWorried = false;
    bool playStressed = false;

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
        audiosource = GetComponent<AudioSource>();
    }

    public void StartTimer()
    {
        timerIsRunning = true;
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
                //Player is caught
            }
        }
    }

    void AssignNewClip(AudioClip newClip)
    {
        audiosource.clip = newClip;
        audiosource.Play();
    }
}
