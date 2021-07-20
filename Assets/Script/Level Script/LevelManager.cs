using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    int levelUnlocked;
    public Button[] buttons;
    bool isMuted = false;
    [SerializeField] AudioSource audio;
    void Start()
    {

        isMuted = PlayerPrefs.GetInt("isMuted", 0) == 1 ? true : false;
        if (!isMuted)
        {
            audio.Play();
        }
        levelUnlocked = PlayerPrefs.GetInt("levelUnlocked", 1);
        Debug.Log(buttons.Length);
        Debug.Log(levelUnlocked);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
        for (int i = 0; i < levelUnlocked; i++)
        {
            buttons[i].interactable = true;
        }
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level+1);
    }
    public void backToHOmeScreen()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
