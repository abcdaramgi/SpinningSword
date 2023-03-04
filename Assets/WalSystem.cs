using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalSystem : MonoBehaviour
{
    BoxCollider2D myCollider;
    // Start is called before the first frame update

    void Start()
    {
        myCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if(SwordFly.gameEnd == true)
            return;
            
        if (other.gameObject.tag == "Knife")
        {
            GetComponent<AudioSource>().Play();
            HitSystem.instance.minusKnife();
        }
    }

    public IEnumerator DisableColliderForSeconds(float seconds)
    {
            myCollider.enabled = false;
            yield return new WaitForSeconds(seconds);
            myCollider.enabled = true;

    }
}
