using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed; // How fast enemy moves toward startPos
    public Vector3 moveOffset; // Amount enemy teleports w each Update call
    private Vector3 targetPos; // Coordinates that trigger IF statement
    private Vector3 startPos; // Coords where enemy starts

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // if Enemy collider touches a GO w tag "Player"...
        {
            other.GetComponent<PlayerController>().GameOver();
        }
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
