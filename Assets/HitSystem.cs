using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSystem : MonoBehaviour
{
    public static HitSystem instance;
    public List<GameObject> knifes = new List<GameObject>();
    public SwordFly swordFly;
    public GameObject knife;
    public WalSystem ws;
    public int count = 0;
    private bool isSideHitted = false;
    public float knifePositionDefault = 0.15f;
    public float knifePositionRange = 0.14f;
    public float hitPositionDefault = 0.085f;
    public float hitPositionRange = 0.06f;
    // Start is called before the first frame update
    void OnEnable()
    {
        if(instance == null)
            instance = this;

        Debug.Log("enable");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            plusKnife();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            minusKnife();
        }

        transform.rotation = Quaternion.Euler(new Vector3(0,0,180));
    }

    public void plusKnife()
    {

        TailController.instance.MakeTail();
        //SwordFly.swordWay = !SwordFly.swordWay;
        
        int a = transform.parent.childCount;

        for (int i = 0; i < a; i++)
            swordFly.jumpSword();
        swordFly.jumpSword();

        GameObject k = Instantiate(knife, Vector3.zero, Quaternion.identity, transform.parent);
        // k.GetComponent<knifeSystem>().hitSystem = this;
        knifes.Add(k);
        
        GetComponent<AudioSource>().Play();
        
        k.transform.localPosition = new Vector3(0, knifePositionDefault + (knifePositionRange * count++), 0);
        k.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        gameObject.transform.localPosition = new Vector3(0, hitPositionDefault + (hitPositionRange * count), 0);
//        Debug.Log(count);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // if (other.tag == "Side")
        // {
        //     Debug.Log("들어간다!");
        //     swordFly.jump2Sword(-1);
        // }

        if(SwordFly.gameEnd == true)
            return;
        
        if (other.tag == "Item")
        {
            if(Mathf.Abs(GetComponentInParent<Rigidbody2D>().angularVelocity) < 300)
            {
                ws.StartCoroutine(ws.DisableColliderForSeconds(0.5f));
                plusKnife();
                StartCoroutine("turnOffAndOn", other.gameObject);
            } else {
                swordFly.rotationPower = -25f;
                swordFly.jumpSword(-1);
                swordFly.rotationPower = -50f;
                // minusKnife();
            }
        }


    }

    IEnumerator turnOffAndOn(GameObject other)
    {
        other.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        other.SetActive(true);
    }

    public void minusKnife()
    {

        TailController.instance.MakeTail();
        //SwordFly.swordWay = !SwordFly.swordWay;
        
        for(int i = 0; i < knifes.Count; i++)
        {
            Destroy(knifes[i].gameObject);
        }
        knifes.Clear();

        --count;
//        Debug.Log(count);

        swordFly.jump2Sword(-1);

        for(int i = 0; i < count; i++)
        {
            GameObject k = Instantiate(knife, Vector3.zero, Quaternion.identity, transform.parent);
            knifes.Add(k);
            k.transform.localPosition = new Vector3(0, knifePositionDefault + (knifePositionRange * i), 0);
            k.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }

        gameObject.transform.localPosition = new Vector3(0, hitPositionDefault + (hitPositionRange * count), 0);
        //Destroy(knifes[--count]);
        //knifes.RemoveAt(--count);
        //gameObject.transform.localPosition = new Vector3(0, hitPositionDefault + (hitPositionRange * count), 0);
    }

    public void GarenSword(){
        for (int i = 0; i < knifes.Count; i++)
        {
            Destroy(knifes[i].gameObject);
        }
        knifes.Clear();
        Debug.Log("Demacia!!!!!!!!!!!!!");
        --count;
        Debug.Log(count);

        swordFly.jumpSword(-1);

        for (int i = 0; i < count; i++)
        {
            GameObject k = Instantiate(knife, Vector3.zero, Quaternion.identity, transform.parent);
            knifes.Add(k);
            k.transform.localPosition = new Vector3(0, knifePositionDefault + (knifePositionRange * i), 0);
            k.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }

        gameObject.transform.localPosition = new Vector3(0, hitPositionDefault + (hitPositionRange * count), 0);
    }
}
