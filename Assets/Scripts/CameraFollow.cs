using UnityEngine;

public class CameraFollow : MonoBehaviour
{
     public Transform target; // The target game object the camera will follow

    void Update()
    {
        if (target != null)
        {
            // Update the camera's position to match the target's position
            // but maintain the camera's current z-axis value
            transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        }
    }
}
