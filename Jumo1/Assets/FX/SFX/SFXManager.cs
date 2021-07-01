using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioSource audio;

    public AudioClip Land;
    public AudioClip Hurt;
    public AudioClip Collect;
    //public AudioClip win;
    public  AudioClip Lose;
    //public AudioClip Click;
    //public AudioClip L;

    public static SFXManager sfxInstance;

    private void Awake()
    {
        if (sfxInstance != null && sfxInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        sfxInstance = this;
        DontDestroyOnLoad(this);
        
    }
}
