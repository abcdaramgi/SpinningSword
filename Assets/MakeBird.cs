using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeBird : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bird;
    public float timeDiff;
    float timer = 0;

    float range = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!SwordFly.gameStart || SwordFly.gameEnd)
            return;

        timer += Time.deltaTime;
        if (timer > timeDiff)
        {
            GameObject newBird = Instantiate(bird);
            newBird.transform.position = new Vector3(6, Random.Range(-1.7f, 5.7f), 0);
            timer = 0;
            Destroy(newBird, 8);
            changeTimeDiff();
        }
    }


    void changeTimeDiff()
    {
        range = Random.Range(0,Score.score);
    }
}
