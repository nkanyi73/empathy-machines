using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnvironmentScript : MonoBehaviour
{
    public bool hasSandwichMakingBegun;
    private float startTime;
    public bool isDominantHandLeft;
    private SkinnedMeshRenderer leftHandRenderer;
    private SkinnedMeshRenderer rightHandRenderer;
    public bool isHandTrackingEnabled;
    public bool isBothHandsPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCounter();
        try
        {
            leftHandRenderer = GameObject.FindGameObjectWithTag("LeftHandMeshRenderer").GetComponent<SkinnedMeshRenderer>();
            rightHandRenderer = GameObject.FindGameObjectWithTag("RightHandMeshRenderer").GetComponent<SkinnedMeshRenderer>();
            if (rightHandRenderer == null )
            {
                Debug.Log("Not Found Right Hand");
            }
            //rightHandRenderer = GameObject.Find("r_handMeshNode").GetComponent<SkinnedMeshRenderer>();
        }
        catch (System.Exception e)
        {
            Debug.LogException(e);
        }
        
        //if (leftHandRenderer == null && rightHandRenderer == null ) 
        //{
        //    Debug.LogError("Skinned Mesh Renderers not Found");
        //}
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
        if (isBothHandsPrefab)
        {
            if (leftHandRenderer.enabled && rightHandRenderer.enabled)
            {
                return true;
            }
            return false;
        }
        else
        {

            if (isDominantHandLeft)
            {
                if (leftHandRenderer.enabled)
                {
                    return true;
                }
            }
            else
            {
                if (rightHandRenderer == null)
                {
                    Debug.Log("Not Found Right Hand");
                    rightHandRenderer = GameObject.FindGameObjectWithTag("RightHandMeshRenderer").GetComponent<SkinnedMeshRenderer>();
                }
                if (rightHandRenderer.enabled)
                {
                    return true;
                }
            }
            return false;
        }
    }

    
}
