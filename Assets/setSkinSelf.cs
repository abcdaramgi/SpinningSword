using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setSkinSelf : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = ImageGetter.instance.getKnifeSkin(PlayerPrefs.GetInt("selectIndex",0));
    }
}
