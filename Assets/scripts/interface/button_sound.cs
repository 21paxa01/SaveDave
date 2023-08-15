using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_sound : MonoBehaviour
{
    public AudioSource sound;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SoundPlay()
    {
        sound.Play();
    }
}
