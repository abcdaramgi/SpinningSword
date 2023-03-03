using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int score = 0;
    public static int bestScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;

        bestScore = PlayerPrefs.GetInt("BestScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        // GetComponent<Text>().text = score.ToString();
        GetComponent<TextMeshProUGUI>().text = score.ToString();
        // gameObject.GetComponent<TextMeshPro>().SetText(score.ToString());
    }
}