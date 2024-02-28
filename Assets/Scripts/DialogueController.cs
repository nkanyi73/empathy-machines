using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Yarn.Unity;

public class DialogueController : MonoBehaviour
{
    public VoiceOverView voiceOverView;

    public AudioSource player;

    public void Start()
    {
        voiceOverView = FindAnyObjectByType<VoiceOverView>();
    }

    [YarnCommand("Set_Audio_To_Player")]
    public void SetAudioSourceToNarrator()
    {
        if (voiceOverView == null)
        {
            voiceOverView = FindAnyObjectByType<VoiceOverView>();
        }
        voiceOverView.audioSource = player;
        Debug.Log("Switching to player Audio Source");

    }
}
