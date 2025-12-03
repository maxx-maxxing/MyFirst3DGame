using UnityEngine;
using UnityEngine.SceneManagement; // Lets you reload scenes (Game Over)
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rig; // drag Rigidbody into this in Inspector

    public float jumpForce;
    public float moveSpeed;
    private bool isGrounded;
    public TextMeshProUGUI scoreText;

    public int score;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.GetContact(0).normal == Vector3.up)
        {
            isGrounded = true;
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddScore(int amount) // Called when coin is collected
    {
        score += amount;
        scoreText.text = $"Score: {score}";
    }

    void Start()
    {
        Debug.Log(score);
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

        if (rig.position.y < -5)
        {
            GameOver();
        }
    }
}
