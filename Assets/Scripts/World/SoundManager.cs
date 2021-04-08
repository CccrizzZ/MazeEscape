using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioSource Key;
    public AudioSource Box;


    public void PlayKeySound()
    {
        Key.Play();
    }


    public void PlayBoxSound()
    {
        Box.Play();
    }
}
