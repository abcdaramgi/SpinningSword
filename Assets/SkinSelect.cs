using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinSelect : MonoBehaviour
{
    public int selectIndex = 0;
    public GameObject selectedSprite;
    public RectTransform ScrollContent;

    public int parseIndex(string str)
    {
        int number = int.Parse(str.TrimStart('(', ' ').TrimEnd(')'));
        Debug.Log(number.ToString());
        return number;
    }
    public void selectKnife(GameObject knife)
    {
        selectedSprite.transform.SetParent(knife.transform.parent);
        selectedSprite.SetActive(true);
        selectedSprite.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0,215,0);

        selectIndex = parseIndex(knife.transform.parent.name);

        ImageGetter.instance.setSkin(selectIndex);

        PlayerPrefs.SetInt("selectIndex",selectIndex);
    }
    // Start is called before the first frame update
    void Start()
    {
        selectIndex = PlayerPrefs.GetInt("selectIndex",0);
        ImageGetter.instance.setSkin(selectIndex);
    }

    // Update is called once per frame
    void Update()
    {
        float x = ScrollContent.anchoredPosition.x;
        ScrollContent.anchoredPosition = new Vector3(x, 0, 0);
    }

    public void loadScrollPosition()
    {
        float x = PlayerPrefs.GetFloat("scroll",0f);

        ScrollContent.anchoredPosition = new Vector3(x, 0, 0);

        PlayerPrefs.SetFloat("scroll",x);

        GameObject target = GameObject.Find(" (" + selectIndex + ")");
        selectKnife(target.transform.GetChild(0).gameObject);
    }
    public void saveScrollPosition()
    {
        float x = selectIndex * -450f;
        PlayerPrefs.SetFloat("scroll",x);
    }

}
