using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeHandle : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject handle;
    public float timeDiff;
    float timer = 0;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > timeDiff){
            GameObject newhandle = Instantiate(handle);
            timer = 0;
            Destroy(newhandle, 5);
        }
        
    }
}
