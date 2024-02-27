using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAudio : MonoBehaviour
{
    public AudioSource cutlerySoundAudioSource;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Counter")
        {
            cutlerySoundAudioSource.Play();
        }
    }
}
