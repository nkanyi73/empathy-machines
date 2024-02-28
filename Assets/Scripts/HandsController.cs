using System.Collections;
using System.Collections.Generic;
using RootMotion.FinalIK;
using UnityEngine;

public class HandsController : MonoBehaviour
{
    public EnvironmentScript env;
    public VRIK vrik;
    public Transform leftControllerTarget, rightControllerTarget, leftHandTarget, rightHandTarget;

    private void Start()
    {
        vrik = GetComponent<VRIK>();
        env = FindObjectOfType<EnvironmentScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (env.CheckHandTracking())
        {
            vrik.solver.leftArm.target = leftHandTarget;
            vrik.solver.rightArm.target = rightHandTarget;
        }
        else
        {
            vrik.solver.leftArm.target = leftControllerTarget;
            vrik.solver.rightArm.target = rightControllerTarget;
        }
    }

}
