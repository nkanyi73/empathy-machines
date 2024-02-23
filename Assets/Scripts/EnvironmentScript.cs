using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentScript : MonoBehaviour
{
    public bool hasSandwichMakingBegun;
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
