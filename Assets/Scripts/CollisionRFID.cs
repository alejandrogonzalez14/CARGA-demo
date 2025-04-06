using UnityEngine;

public class SphereCollision : MonoBehaviour
{
    // Reference to the Renderer component to change color
    private Renderer sphereRenderer;

    // Store the original color of the sphere
    private Color originalColor;

    void Start()
    {
        // Get the Renderer component attached to the sphere
        sphereRenderer = GetComponent<Renderer>();

        // Store the original color of the sphere at the start
        originalColor = sphereRenderer.material.color;
    }

    // This method is called when another collider enters the trigger zone
    void OnTriggerEnter(Collider other)
    {
        // Change the color to green when something enters the trigger zone
        sphereRenderer.material.color = Color.green;
    }

    // This method is called when another collider exits the trigger zone
    void OnTriggerExit(Collider other)
    {
        // Restore the original color when the object exits the trigger zone
        sphereRenderer.material.color = originalColor;
    }
}
