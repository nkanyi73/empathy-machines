using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadingScript : MonoBehaviour
{
    public GameObject mayoSphere;
    public GameObject butterSphere;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Mayo" && this.gameObject.tag == "Spoon")
        {
            mayoSphere.SetActive(true);
        }

        if (collision.gameObject.tag == "Butter" && this.gameObject.tag == "Butter Knife")
        {
            butterSphere.SetActive(true);
        }
    }
}
