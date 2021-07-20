using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField] private AudioSource audio;
    private void Start()
    {
        bool isMuted = PlayerPrefs.GetInt("isMuted", 0) == 1 ? true : false;
        if (!isMuted)
        {
            audio.Play();
        }
    }
    public void ReplayGame()
    {
        SceneManager.LoadScene(2);
    }
    public void GotoHome()
    {
        SceneManager.LoadScene(0);
    }
}
