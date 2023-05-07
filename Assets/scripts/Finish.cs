using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Finish : MonoBehaviour
{
    [SerializeField]
    private GameObject snowman;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        var player = collider.GetComponent<PlayerMovement>();
        if (player != null)
        {
            Vector3 scale = player.transform.localScale;
            if (Mathf.Abs(scale.x) < 0.7f && Mathf.Abs(scale.y) < 0.7f)
            {
                Destroy(player.gameObject);
                this.gameObject.SetActive(false);
                snowman.SetActive(true);
            }

        }
        else
        {
            Debug.Log("Špatná velikost koule");
        }
    }
}
