using UnityEngine;

public class RepositionOnDrop : MonoBehaviour
{
    public Vector3 startPosition;       // Set the initial position in the Unity Editor
    public float dropThreshold = -5f;    // Set the drop threshold in the Unity Editor

    void Start()
    {
        startPosition = transform.position;  // Save the initial position
    }

    void Update()
    {
        // Check if the GameObject has dropped below the threshold
        if (transform.position.y < dropThreshold)
        {
            Reposition();
            Debug.Log("Reposition!");
        }
    }

    void Reposition()
    {
        // Reset the position to the initial position
        transform.position = startPosition;

        // You can add additional actions here after repositioning if needed
    }
}
