using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUp : MonoBehaviour
{
    private bool isHit = false;
    private void OnTriggerEnter2D(Collider2D other) {
        if(!isHit){
            if(other.gameObject.tag == "Knife"){
                isHit = true;
                SparkSystem.instance.genFeather(transform.position);
                Score.score++;
                HitSystem.instance.minusKnife();
                GetComponent<AudioSource>().Play();
                gameObject.transform.position = new Vector3(100, 100, 100);
                Destroy(gameObject, 3);
            }
        }
    }
}
