using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    [SerializeField] AudioSource deathSOundEffect;
    bool isMuted = false;

    public GameObject heart1, heart2, heart3;
    public GameObject gameOverMessagePanel,pauseButton;
    [SerializeField] AudioSource audio;
    bool isCollideAlready = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        isMuted = PlayerPrefs.GetInt("isMuted", 0) == 1 ? true : false;
        checkAndUpdateplayerLife(GameController.playerLifeCount);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Trap") && !isCollideAlready)
        {
            Debug.Log("OnCollisionEnter2D:::");
            if (!isMuted)
            {
                deathSOundEffect.Play();
            }
            GameController.playerLifeCount -= 1;
            isCollideAlready = true;
            Die();
            
        }
    }
    private void Die()
    {
        anim.SetTrigger("death");
        rb.bodyType = RigidbodyType2D.Static;
        checkAndUpdateplayerLife(GameController.playerLifeCount);
    }
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void checkAndUpdateplayerLife(int playerLifeCount)
    {
        
        switch (playerLifeCount)
        {
            case 3:
                {
                    heart1.gameObject.SetActive(true);
                    heart2.gameObject.SetActive(true);
                    heart3.gameObject.SetActive(true);
                    break;
                }
            case 2:
                {
                    heart1.gameObject.SetActive(true);
                    heart2.gameObject.SetActive(true);
                    heart3.gameObject.SetActive(false);
                    break;
                }
            case 1:
                {
                    heart1.gameObject.SetActive(true);
                    heart2.gameObject.SetActive(false);
                    heart3.gameObject.SetActive(false);
                    break;
                }
            case 0:
                {
                    heart1.gameObject.SetActive(false);
                    heart2.gameObject.SetActive(false);
                    heart3.gameObject.SetActive(false);
                    
                    Invoke("GameOver", 1f);
                   
                    //AdsManager.PlayAds();
                    break;

                }
        }
    }
    private void GameOver()
    {
        Time.timeScale = 0f;
        pauseButton.SetActive(false);
        gameOverMessagePanel.SetActive(true);
        audio.Pause();
    }
}
