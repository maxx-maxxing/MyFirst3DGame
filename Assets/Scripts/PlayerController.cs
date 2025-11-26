using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rig; // drag Rigidbody into this in Inspector

    public float jumpForce;
    public float moveSpeed;
    private bool isGrounded;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.GetContact(0).normal == Vector3.up)
        {
            isGrounded = true;
        }
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal") * moveSpeed;
        float z = Input.GetAxisRaw("Vertical") * moveSpeed;

        // 1. Control horizontal movement, keep vertical physics
        rig.linearVelocity = new Vector3(x, rig.linearVelocity.y, z);

        // 2. Copy velocity and flatten it so we ignore Y for facing
        Vector3 vel = rig.linearVelocity;
        vel.y = 0;

        // 3. Only rotate if we’re actually moving on X/Z
        if (vel.x != 0 || vel.z != 0)
        {
            transform.forward = vel;
        }

        // 4. Jump only when grounded
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            isGrounded = false;
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
