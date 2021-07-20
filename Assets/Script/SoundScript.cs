using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    [SerializeField] AudioSource audio;
    void Start()
    {

        bool isMuted = PlayerPrefs.GetInt("isMuted", 0) == 1 ? true : false;
        Debug.Log("ISMUTED::" + isMuted);
        if (isMuted)
        {
            audio.mute = true;
        }
        else
        {
            audio.mute = false;
            audio.Play();

        }
        
    }

    
}
