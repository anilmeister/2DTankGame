using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class Sounds : MonoBehaviour
{
    // Start is called before the first frame update
    public string audioName;

    public bool loop;

    public AudioClip audioClip;

    [Range(0f, 1f)]
    public float volume;
    [Range (.1f, 5f)]
    public float pitch;


    [HideInInspector]
    public AudioSource audioSource;

}
