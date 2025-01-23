using UnityEngine;
using System.Threading;

public class AudioControl : MonoBehaviour
{
    //variables
    public AudioSource audioBackground;
    public AudioSource audioEatSound;
    public AudioSource audioGameOver;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayBackgroundSound()
    {
        audioBackground.Play();
    }
    public void StopBackgroundSound()
    {
        audioBackground.Stop();
    }

    public void PlayEatSound()
    {
        audioEatSound.Play();
    }
    public void PlayGameOverSound()
    {
        StopBackgroundSound();
        audioGameOver.Play();
        //Thread.Sleep(2000);
    }
}
