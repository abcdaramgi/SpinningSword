using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailController : MonoBehaviour
{
    public static TailController instance;
    public TrailRenderer trailRenderer;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
            instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeTail()
    {
        StopCoroutine("tailCoroutine");
        StartCoroutine("tailCoroutine");
    }

    IEnumerator tailCoroutine()
    {
        trailRenderer.emitting = true;
        yield return new WaitForSeconds(0.2f);

        trailRenderer.emitting = false;
    }
}
