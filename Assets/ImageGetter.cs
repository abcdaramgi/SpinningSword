using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageGetter : MonoBehaviour
{
    public SpriteRenderer targetHandle;
    public SpriteRenderer targetKnife;
    public static ImageGetter instance;
    public List<Sprite> handleList = new List<Sprite>();
    public List<Sprite> knifeList = new List<Sprite>();

    private void Awake() {
        if(instance == null)
            instance = this;
    }
    
    public void setSkin(int index = 0)
    {
        targetHandle.sprite = handleList[index];
        targetKnife.sprite = knifeList[index];
    }
    public Sprite getKnifeSkin(int index = 0)
    {
        return knifeList[index];
    }
}
