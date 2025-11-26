using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Update is called once per frame

    public Rigidbody rig; // Initialize Rigidbody when you want to control the physics of the GO
                          // Back in inspector, c&d the rigidbody component to the Rig reference in the script component

    public float jumpForce; // factor by which to increase magnitude
    public float moveSpeed; // factor by which to increase magnitude
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal") * moveSpeed; // If input is D, x = 1; if A, x = -1
        float z = Input.GetAxisRaw("Vertical") * moveSpeed; // If input is W, z = 1; if S, z = -1

        rig.linearVelocity = new Vector3(x, rig.linearVelocity.y, z); // linearVelocity is being checked every frame.

        if (Input.GetKeyDown(KeyCode.Space)) // When key is pressed down
        {
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Add a Y force, with impulse-type force
        }
    }
}
