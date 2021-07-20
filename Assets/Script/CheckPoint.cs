using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour

{
    private GameMaster gm;
    [SerializeField] AudioSource checkPointSound;
    bool isMuted = false;
    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        isMuted = PlayerPrefs.GetInt("isMuted", 0) == 1 ? true : false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("TRIGE asdE");
            if (!isMuted)
            {
                checkPointSound.Play();
            }
            gm.lastCheckPointPos = transform.position; 
        }
    }

}
