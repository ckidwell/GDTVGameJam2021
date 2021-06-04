using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    GameController gamecontroller;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioSource policeChatter;

    [SerializeField] float timeRemaining = 120;
    [SerializeField] float timeToStartWorriedClip = 60;
    [SerializeField] float timeToStartStressedClip = 10;
    bool timerIsRunning = false;

    [SerializeField] AudioClip calmMusic;
    [SerializeField] AudioClip worriedMusic;
    [SerializeField] AudioClip stressedMusic;
    [SerializeField] AudioClip radioClip;
    [SerializeField] AudioClip radioClip2;
    [SerializeField] AudioClip sirenClip;

    bool playCalm = true;
    bool playWorried = false;
    bool playStressed = false;

    bool playChatter1 = true;
    bool playChatter2 = false;

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
        if (playChatter1)
        {
            Debug.Log("play chatter");
            policeChatter.PlayOneShot(radioClip);
            playChatter1 = false;
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
                        policeChatter.PlayOneShot(radioClip2);
                        AssignNewClip(worriedMusic);
                    }
                }
                if (timeRemaining < timeToStartStressedClip)
                {
                    if (playWorried == true)
                    {
                        playWorried = false;
                        playStressed = true;
                        policeChatter.clip = sirenClip;
                        AssignNewClip(stressedMusic);
                        policeChatter.Play();
                    }
                }
            }
            else
            {
                gamecontroller.PlayerCaught();
            }
        }
    }

    public void StopTimer()
    {
        timerIsRunning = false;
        audioSource.Stop();
    }
    void AssignNewClip(AudioClip newClip)
    {
        audioSource.clip = newClip;
        audioSource.Play();
    }
}
