using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip[] songs;
    private AudioSource audioSource;
    private int playingSong;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.clip = songs[0];
        audioSource.Play();
    }

    public void GetSong(int s)
    {
        if (s != playingSong)
        {
            playingSong = s;
            audioSource.clip = songs[playingSong];
            audioSource.Play();
        }
    }
}