using UnityEngine;

//Code written by Microsoft Copilot
public class Saber_Controller : MonoBehaviour
{
    void Update()
    {
        // Get the mouse position in world coordinates
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Set Z to 0 since we're working in 2D

        // Calculate the direction from the object to the mouse
        Vector3 direction = mousePosition - transform.position;

        // Calculate the angle to rotate the object
        float angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg) - 90;

        // Apply the rotation to the object
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
