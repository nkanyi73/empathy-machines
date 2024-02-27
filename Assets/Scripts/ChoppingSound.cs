using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoppingSound : MonoBehaviour
{
    public AudioSource vegetableChoppingAudioSource;
    public VelocityTracker velocityTracker;
    public bool isTouchedTomato;

    private void Start()
    {
        isTouchedTomato = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Tomato")
        {
            isTouchedTomato = true;
            Debug.Log("Chopping sound played!");
        }
    }
    void Update()
    {
        PlayChoppingAudio();
    }

    public void PlayChoppingAudio()
    {
        if (velocityTracker.atChoppingSpeed && isTouchedTomato)
        {
            vegetableChoppingAudioSource.Play();
        }
    }
}
