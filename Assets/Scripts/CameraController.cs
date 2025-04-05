using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    public Vector3 offset;

    // Start is called before the first frame update.
    void Start()
    {
        // Ensure that the camera starts with the correct offset.
        transform.position = player.transform.position + offset;
    }

    // LateUpdate is called once per frame after all Update functions have been completed.
    void LateUpdate()
    {
        Vector3 targetPosition = player.transform.position + offset;

        transform.position = targetPosition;

        transform.LookAt(player.transform);
    }
}
