using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
     public float forceMultiplier = 10f; // The amount of force applied to the player when dragged
    public LineRenderer directionLine; // A line renderer to display the direction the player will go

    private Vector2 dragStartPos; // The starting position of the player drag
    private Rigidbody2D rb; // The player's Rigidbody2D component

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        directionLine.enabled = false; // Disable the direction line initially
    }

    private void OnMouseDown()
    {
        dragStartPos = transform.position;
        directionLine.enabled = true; // Enable the direction line when the player is clicked
    }

    private void OnMouseDrag()
    {
        Vector2 dragDelta = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position) * -1f;
        directionLine.SetPosition(0, transform.position);
        directionLine.SetPosition(1, transform.position + (Vector3)dragDelta.normalized * 2f); // The line will be 2 units long
    }

    private void OnMouseUp()
    {
        Vector2 dragDelta = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position) * -1f;
        rb.AddForce(dragDelta * forceMultiplier, ForceMode2D.Force);
        directionLine.enabled = false; // Disable the direction line when the player is released
    }
}
