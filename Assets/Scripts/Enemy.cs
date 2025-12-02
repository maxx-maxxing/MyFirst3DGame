using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed; // How fast enemy moves toward startPos
    public Vector3 moveOffset; // Amount enemy teleports w each Update call
    [SerializeField]
    private Vector3 targetPos; // Coordinates that trigger IF statement
    [SerializeField]
    private Vector3 startPos; // Coords where enemy starts

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // if Enemy collider touches a GO w tag "Player"...
        {
            other.GetComponent<PlayerController>().GameOver();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 from;
        Vector3 to;
        
        if (Application.isPlaying)
        {
            from = startPos;
            to = startPos + moveOffset;
        }
        else
        {
            from = transform.position;
            to = transform.position + moveOffset;
        }
        Gizmos.DrawLine(from, to);
        Gizmos.DrawWireSphere(from, .2f);
        Gizmos.DrawWireSphere(to, .2f);
        
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
        targetPos = startPos;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        // Every frame, if transform.position != targetPos, enemy position updates to move closer to targetPos
        if (transform.position == targetPos)
        {
            transform.position = startPos + moveOffset;
        }
        else
        {
            targetPos = startPos;
        }
    }
}
