using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using UnityEngine;

public class PlaceSandwichElement : MonoBehaviour
{
    private bool hasCollided;
    private Grabbable grabbable;
    private Rigidbody rb;
    public Transform breadPrefab;

    public void Start()
    {
        grabbable = GetComponent<Grabbable>();
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bread"))
        {
            hasCollided = true;
            Debug.Log("Collision Detected");
        }
    }

    public void DeactivateGrab()
    {
        if(hasCollided)
        {
            Debug.Log("Deactivating Grab");
            grabbable.enabled = false;
            rb.useGravity = false;
            rb.isKinematic = true;
            transform.SetParent(breadPrefab);
        }

    }

}
