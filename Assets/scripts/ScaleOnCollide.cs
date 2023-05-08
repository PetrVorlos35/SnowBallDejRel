using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleOnCollide : MonoBehaviour
{
    private float initialScale;
    public Animator treeAnimator;
    public float speed = 10f;
    public float boostedSpeed = 20f;


    void Start()
    {
        // Store the initial scale of the snowball
        initialScale = transform.localScale.x;

        // Get the Animator component attached to the snowball
        treeAnimator = GameObject.Find("Tree").GetComponent<Animator>();

    }
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput) * speed * Time.deltaTime;
        transform.Translate(movement);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tree"))
        {
            // Reduce the scale of the snowball by half when it hits a tree
            transform.localScale = new Vector3(initialScale / 2f, initialScale / 2f, transform.localScale.z);

            // Start the "SnowballHit" animation
            treeAnimator.SetTrigger("StromMoveController");
        }
        if (collision.gameObject.CompareTag("Booster"))
        {
            
            transform.localScale = new Vector3(initialScale / 2f, initialScale / 2f, transform.localScale.z);
            speed = boostedSpeed;

            // Set a timer to restore the speed after some time (e.g. 5 seconds)
            StartCoroutine(RestoreSpeed(5f));

        }
    }
    IEnumerator RestoreSpeed(float time)
    {
        yield return new WaitForSeconds(time);
        speed = 10f;
    }
}
