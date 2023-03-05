using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public List<AudioClip> clips;
    public bool isPlay = true;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
            instance = this;
    }

    public void playSound(int index)
    {
        if(clips[index] == null)
            index = 0;

        GameObject sound = new GameObject();
        sound.AddComponent<AudioSource>().clip = clips[index];
        sound.GetComponent<AudioSource>().Play();
        sound.GetComponent<AudioSource>().volume = 0.5f;

        Destroy(sound,1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
