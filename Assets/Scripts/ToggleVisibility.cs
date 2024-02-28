using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleVisibility : MonoBehaviour
{
    public GameObject nextButton;
    private float startTime;

    void Start()
    {
        // Record the start time
        startTime = Time.time;
    }

    bool HasTenSecondsPassed()
    {
        // Check if the current time minus the start time is greater than or equal to 10 seconds
        return Time.time - startTime >= 10.0f;
    }

    public void DeactivateButton()
    {
        nextButton.SetActive(false);
    }

    void Update()
    {
        // Example usage: if 10 seconds have passed, print a message
        if (HasTenSecondsPassed())
        {
            if(nextButton.activeSelf)
            {
                nextButton.SetActive(false);
            } 
        }
    }
}
