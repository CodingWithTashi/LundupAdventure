using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private bool leveCompleted = false;
    private AudioSource finishSound;
    bool isMuted = false;
    private GameMaster gm;
    void Start()
    {
        finishSound = GetComponent<AudioSource>();
         isMuted = PlayerPrefs.GetInt("isMuted", 0) == 1 ? true : false ;
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !leveCompleted)
        {
            if (!isMuted)
            {
                finishSound.Play();
            }
            
            leveCompleted = true;
           Invoke("CompleteLevel", 2f);

        }
    }
  
    private void CompleteLevel()
    {
        //Player POstition shoud be in start
        gm.lastCheckPointPos = gm.originalPosition;

        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        if (currentLevel >= PlayerPrefs.GetInt("levelUnlocked"))
        {
            PlayerPrefs.SetInt("levelUnlocked", currentLevel);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
