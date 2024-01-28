using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource musicSource;
    private AudioClip musicClip;
    [SerializeField]
    private List<MusicInfo> musicList;

    private void Start()
    {
        musicSource = GetComponent<AudioSource>();
    }

    public void SwitchMusic(string state)
    {
        foreach (MusicInfo info in musicList)
        {
            if (info.stateName == state)
            {
                musicSource.loop = info.loop;
                musicSource.clip = info.audioClip;
            }
        }
        musicSource.Play();
    }
}

[System.Serializable]
public class MusicInfo
{
    public string stateName; //name of the state of the game to play the music in
    public AudioClip audioClip; //audio clip to play
    public bool loop; //will loop if true
}