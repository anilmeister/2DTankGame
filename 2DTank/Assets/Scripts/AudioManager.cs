
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

    private GameObject soundGameObject;
    private ObjectPool pool;
    private AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        soundGameObject = new GameObject("Sound");
        soundGameObject.AddComponent<AudioSource>();
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

    public void PlaySound(int index)
    {
        if (soundGameObject == null) { 
            soundGameObject = new GameObject("Sound");
            audioSource = soundGameObject.AddComponent<AudioSource>();
        }
        else
            audioSource = soundGameObject.GetComponent<AudioSource>();

        audioSource.volume = 0.2f;
        audioSource.PlayOneShot(clips[index]);
    }



}
