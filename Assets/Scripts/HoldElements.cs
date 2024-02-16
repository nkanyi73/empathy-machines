using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldElements : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sliceable"))
        {
            Debug.Log("At Bread");
            PlaceSandwichElement element = collision.gameObject.GetComponent<PlaceSandwichElement>();
            element.DeactivateGrab();

        }
    }
}
