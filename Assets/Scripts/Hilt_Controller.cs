using UnityEngine;

//Code written by Microsoft Copilot
public class Saber_Controller : MonoBehaviour
{
    public Transform player;  // Reference to the player
    public float speed = 5f;  // Rotation speed

    private float radius = 2.50f; // the lightsaber can only move within this radius
    private bool leftClickPushed = false; // boolean for if left click is pushed

    void Update() {
         // Check if the left mouse button is pressed
        if (Input.GetMouseButtonDown(0)) {
            leftClickPushed = true;
        } else if (Input.GetMouseButtonUp(0)) {
            leftClickPushed = false;
        }
        //convert mouse position to world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
    if (leftClickPushed == false) {

        // Calculate direction from player to mouse
        Vector3 direction = mousePosition - transform.position;

        // Calculate the angle to rotate the object
        float angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg) - 90;

        // Apply the rotation to the object
        transform.rotation = Quaternion.Euler(0, 0, angle);
        
        transform.position = player.position;

    } else {
        //created by Github Copilot
         // Calculate the direction from the player to the mouse position
            Vector3 direction = mousePosition - player.position;

            // Clamp the direction to the radius
            if (direction.magnitude > radius) {
                direction = direction.normalized * radius;
            }

            // Set the position within the radius
            transform.position = player.position + direction;
    }
    }
}
