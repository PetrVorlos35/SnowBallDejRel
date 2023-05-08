using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleOnCollide : MonoBehaviour
{
    private float initialScale;
    public Animator treeAnimator;


    void Start()
    {
        // Store the initial scale of the snowball
        initialScale = transform.localScale.x;

        // Get the Animator component attached to the snowball
        treeAnimator = GameObject.Find("Tree").GetComponent<Animator>();

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
    }
}
