using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadingScript : MonoBehaviour
{
    public GameObject mayoSphere;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Mayo")
        {
            mayoSphere.SetActive(true);
        }
    }
}
