using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentScript : MonoBehaviour
{
    public bool hasSandwichMakingBegun;
    private float startTime;
    public bool isDominantHandLeft;
    public SkinnedMeshRenderer leftHandRenderer;
    public SkinnedMeshRenderer rightHandRenderer;
    public bool isHandTrackingEnabled;
    // Start is called before the first frame update
    void Start()
    {
        isDominantHandLeft = true;
    }

    // Update is called once per frame
    void Update()
    {
        isHandTrackingEnabled = CheckHandTracking();
    }

    public void StartCounter()
    {
        startTime = Time.time;
        Debug.Log("Timer Started");
    }

    public float StopCounter()
    {
        float elapsedTime = Time.time - startTime;
        Debug.Log("Timer ended. Elapsed time: " + elapsedTime + " seconds.");
        return elapsedTime;
    }

    public bool CheckHandTracking()
    {
        if(isDominantHandLeft)
        {
            if (leftHandRenderer.enabled) 
            {
                return true;
            }
        } 
        else
        {
            if(!rightHandRenderer.enabled)
            {
                return true;
            }
        }
        return false;
    }

    
}
