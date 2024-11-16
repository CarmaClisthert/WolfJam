using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's Transform
    public float smoothSpeed = 0.125f; // Smoothing factor for camera movement
    public float offsetY = 2f; // Vertical offset for the camera

    private float lowestY; // To prevent the camera from moving down

    void Start()
    {
        if (player != null)
        {
            // Initialize the lowest point the camera can move to
            lowestY = transform.position.y;
        }
    }

    void LateUpdate()
    {
        if (player != null)
        {
            // Calculate the new position
            Vector3 targetPosition = new Vector3(transform.position.x, Mathf.Max(lowestY, player.position.y + offsetY), transform.position.z);

            // Smoothly interpolate to the target position
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
        }
    }
}
