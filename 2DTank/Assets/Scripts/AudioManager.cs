
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update

    public Sounds[] sounds;

    private void Awake()
    {
        foreach( Sounds s in sounds )
        {
            //s.source = gameObject.AddComponent<AudioSource>();
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
