using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField]
    private GameObject snowman;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        var player = collider.GetComponent<PlayerMovement>();
        if (player != null)
        {
            Destroy(player.gameObject);
            this.gameObject.SetActive(false);
            snowman.SetActive(true);
        }
    }
}
