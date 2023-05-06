using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float forceMultiplier = 10f;
    public float stopThreshold = 1f;
    public float damping = 0.5f;
    public LineRenderer directionLine;

    private Vector2 dragStartPos;
    private Rigidbody2D rb;
    private bool isDragging = false;
    private float lastVelocity = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        directionLine.enabled = false;
    }

    private void Update()
    {
        if (!isDragging && rb.velocity.magnitude < stopThreshold)
        {
            rb.velocity *= damping;
            if (Mathf.Abs(rb.velocity.magnitude - lastVelocity) < 0.01f)
            {
                rb.velocity = Vector2.zero;
            }
            lastVelocity = rb.velocity.magnitude;
        }
    }

    private void OnMouseDown()
    {
        dragStartPos = transform.position;
        directionLine.enabled = true;
        isDragging = true;
    }

    private void OnMouseDrag()
    {
        Vector2 dragDelta = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position) * -1f;
        directionLine.SetPosition(0, transform.position);
        directionLine.SetPosition(1, transform.position + (Vector3)dragDelta.normalized * 2f);
    }

    private void OnMouseUp()
    {
        Vector2 dragDelta = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position) * -1f;
        rb.AddForce(dragDelta * forceMultiplier, ForceMode2D.Force);
        directionLine.enabled = false;
        isDragging = false;
    }
}
