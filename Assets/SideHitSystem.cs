using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideHitSystem : MonoBehaviour
{
    private bool isHitted = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        isHitted = !isHitted;
        GetComponent<AudioSource>().Play();
    }
}
