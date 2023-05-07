using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Finish : MonoBehaviour
{
    [SerializeField]
    private GameObject snowman;

    [SerializeField]
    private Canvas WinScreen;
    [SerializeField]
    private Canvas LooseScreen;

    private void Awake()
    {
        WinScreen.enabled = false;
        LooseScreen.enabled = false;
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        var player = collider.GetComponent<PlayerMovement>();
        if (player != null)
        {
            Vector3 scale = player.transform.localScale;
            if (Mathf.Abs(scale.x) < 0.7f && Mathf.Abs(scale.y) < 0.7f)
            {
                Time.timeScale = 0;
                this.gameObject.SetActive(false);
                snowman.SetActive(true);
                WinScreen.enabled = true;
            }else
            {
                Time.timeScale = 0;
                LooseScreen.enabled = true;
            }
        }
    }
}
