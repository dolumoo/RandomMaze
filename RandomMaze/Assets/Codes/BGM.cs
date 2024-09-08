using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    public AudioSource audiosource;
    public AudioClip backGroundMusic;

    private void Start()
    {
        if(audiosource != null && backGroundMusic != null)
        {
            audiosource.clip = backGroundMusic;
            audiosource.loop = true;
            audiosource.Play();
        }
    }
}
