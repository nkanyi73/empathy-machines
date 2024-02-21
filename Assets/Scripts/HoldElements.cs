using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;

public class HoldElements : MonoBehaviour
{
    public EnvironmentScript env;
    public GameObject[] breadSlices;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sliceable"))
        {
            Debug.Log("Hold Elements Script");
            if (!env.hasSandwichMakingBegun)
            {
                env.hasSandwichMakingBegun = true;
                ChangeBreadTag();
                breadSlices = GameObject.FindGameObjectsWithTag("Bread");

                for (int i = 0; i < breadSlices.Length; i++)
                {
                    MeshCollider collider =  breadSlices[i].GetNamedChild("Object_8").GetComponent<MeshCollider>();
                    collider.excludeLayers = LayerMask.GetMask("Sliceable");
                }
            }
            Debug.Log("At Bread");
            PlaceSandwichElement element = collision.gameObject.GetComponent<PlaceSandwichElement>();
            element.breadPrefab = transform;
            element.DeactivateGrab();

        }
    }

    private void ChangeBreadTag()
    {
        this.gameObject.tag = "Bottom Bread";
        this.GetComponent<Rigidbody>().isKinematic = true;
    }
}
