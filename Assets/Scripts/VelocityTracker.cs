using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityTracker : MonoBehaviour
{
    public float velocityThreshold; // Threshold velocity value
    public float timeInterval; // Time interval for velocity calculation
    private Vector3 previousPosition;
    public bool isGrabbed;
    public bool atChoppingSpeed;

    void Start()
    {
        previousPosition = transform.position; // Initialize the previous position
        //InvokeRepeating("CalculateVelocity", 0f, timeInterval); // Start the velocity calculation
    }

    private void Update()
    {
        if(isGrabbed)
        {
            CalculateVelocity();
        }
    }

    void CalculateVelocity()
    {
       // previousPosition = transform.position; // Initialize the previous position

        Vector3 currentPosition = transform.position;
        Vector3 displacement = currentPosition - previousPosition;
        float velocityMagnitude = displacement.magnitude / timeInterval;

        if (velocityMagnitude >= velocityThreshold)
        {
            //Debug.Log("Object velocity has reached the threshold: " + velocityMagnitude);
            atChoppingSpeed = true;
            // You can perform additional actions here if needed
        }
        else
        {
            atChoppingSpeed = false;
        }

        previousPosition = currentPosition; // Update the previous position

    } 

    public void PickedUpKnife()
    {
        isGrabbed = true;
        Debug.Log("Knife Picked Up");
    }

    public void ReleasedKnife()
    {
        isGrabbed = false;
        Debug.Log("Knife Dropped");

    }
}


