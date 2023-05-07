using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBallScalling : MonoBehaviour
{
    public GameObject snowballPrefab;
    public float baseGrowthRate = 0.1f;
    GameObject snowball;
    Coroutine growCoroutine;

    private void Start()
    {
        snowball = Instantiate(snowballPrefab, transform.position, Quaternion.identity);
    }

    void Update()
    {
        // Check if the snowball is moving
        if (snowball.GetComponent<Rigidbody2D>().velocity.magnitude > 0f)
        {
            // If the snowball is moving and the coroutine is not already running, start growing the snowball
            if (growCoroutine == null)
            {
                growCoroutine = StartCoroutine(GrowSnowball(snowball));
            }
        }
        else
        {
            // If the snowball is not moving and the coroutine is running, stop growing the snowball
            if (growCoroutine != null)
            {
                StopCoroutine(growCoroutine);
                growCoroutine = null;
            }
        }
    }

    IEnumerator GrowSnowball(GameObject snowball)
    {
        while (snowball.transform.localScale.x < 10f)
        {
            float growthRate = baseGrowthRate / snowball.transform.localScale.x / 10;
            snowball.transform.localScale += new Vector3(growthRate, growthRate, 0f) * 0.5f;
            yield return new WaitForSeconds(0.3f);
        }
    }
}
