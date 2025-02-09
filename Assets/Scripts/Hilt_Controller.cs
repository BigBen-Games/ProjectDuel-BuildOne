using UnityEngine;

//Code written by Microsoft Copilot
public class Saber_Controller : MonoBehaviour
{
    public Transform player;  // Reference to the player
    public float speed = 5f;  // Rotation speed
    bool leftClickPushed; // boolean for if left click is pushed

    void Update() {
    
        //convert mouse position to world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        // Calculate direction from player to mouse
        Vector3 direction = mousePosition - transform.position;

        // Calculate the angle to rotate the object
        float angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg) - 90;

        // Apply the rotation to the object
        transform.rotation = Quaternion.Euler(0, 0, angle);
        
        transform.position = player.position;
    }
}
