using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkSystem : MonoBehaviour
{
    public GameObject redSpark;
    public GameObject blueSpark;
    public static SparkSystem instance;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void genRedSpark(Vector3 pos)
    {
        GameObject temp = Instantiate(redSpark,pos,Quaternion.identity);
        Destroy(temp,0.5f);
    }
    public void genBlueSpark(Vector3 pos)
    {
        GameObject temp = Instantiate(blueSpark,pos,Quaternion.identity);
        Destroy(temp,0.5f);
    }
}
