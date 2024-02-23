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
            PlaceSandwichElement element = collision.gameObject.GetComponent<PlaceSandwichElement>();
            element.breadPrefab = transform;
            element.DeactivateGrab();

        }

        if(collision.gameObject.CompareTag("Basil"))
        {
            Debug.Log("Basil Detected");
            PlaceSandwichElement element = collision.gameObject.GetComponent<PlaceSandwichElement>();
            element.breadPrefab = transform;
            element.DeactivateGrab();
        }

        if (collision.gameObject.CompareTag("Bread"))
        {
            if(env.hasSandwichMakingBegun)
            {
                collision.gameObject.transform.SetParent(transform, false);
                collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                collision.gameObject.GetComponent<Rigidbody>().useGravity = false;
                collision.gameObject.transform.localScale = Vector3.one;
            }
        }
    }

    private void ChangeBreadTag()
    {
        this.gameObject.tag = "Bottom Bread";
        this.GetComponent<Rigidbody>().isKinematic = true;
    }
}
