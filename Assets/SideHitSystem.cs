using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideHitSystem : MonoBehaviour
{
    private bool isHitted = false;

    private void OnTriggerEnter2D(Collider2D other) {
        isHitted = !isHitted;
        GetComponent<AudioSource>().Play();
    }
}
