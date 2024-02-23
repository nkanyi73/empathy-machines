using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction.HandGrab;
using UnityEngine;

public class PlaceBasil : MonoBehaviour
{
    private Rigidbody rb;
    private HandGrabInteractable interactable;
    public EnvironmentScript env;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        interactable = GetComponent<HandGrabInteractable>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (env.hasSandwichMakingBegun)
        {
            if (collision.gameObject.CompareTag("Bottom Bread"))
            {
                transform.SetParent(collision.gameObject.transform);
                //grabbable.enabled = false;
                rb.useGravity = false;
                rb.isKinematic = true;
                //interactable.enabled = false;
                Debug.Log("Basil Collision Detected");
            }
        }
    }


}
