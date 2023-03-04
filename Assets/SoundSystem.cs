using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource BirdSound{ get { return GetComponent<AudioSource>(); } }
}
