
using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update

    //Sound array
    public Sounds[] sounds;

    public AudioClip[] clips;

    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }


        DontDestroyOnLoad(gameObject);
        foreach ( Sounds s in sounds )
        {   
            s.audioSource = gameObject.AddComponent<AudioSource>(); 
            s.audioSource.clip = s.audioClip;
            s.audioSource.volume = s.volume;
            s.audioSource.pitch = s.pitch;
            s.audioSource.loop = s.loop;
        }
    }


    public void Play (string name)
    {
        //FindObjectOfType<AudioManager>().Play("PlayerDeath");
        Sounds s = Array.Find(sounds, s => s.name == name);
        s.audioSource.Play();
    }

    public void PlaySound (int index)
    {
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(clips[index]);
    }



}
