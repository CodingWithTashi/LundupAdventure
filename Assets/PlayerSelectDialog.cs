using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerSelectDialog : MonoBehaviour
{
    [SerializeField] GameObject selectPlayerMenu;
    [SerializeField] GameObject prevButton;
    [SerializeField] GameObject nextButton;
    [SerializeField]  List<Sprite> spriteList;
    [SerializeField] Image selectedPlayer;

    int index = 0;


    private void Start()
    {
        //imageList[index].SetActive(true);
        /*bool messageDisplayed = PlayerPrefs.GetInt("messageDisplayed", 0) == 1 ? true : false;

        if (!messageDisplayed)
        {

            selectPlayerMenu.SetActive(true);
        }*/
        selectedPlayer.sprite = spriteList[index];
        prevButton.SetActive(false);
    }
    public void exitDialog()
    {
        selectPlayerMenu.SetActive(false);
    }
    public void showPlayerSelectDialog()
    {
        selectPlayerMenu.SetActive(true);
    }
    public void showNextPlayer()
    {
        index++;
        Debug.Log("showNextPlayer::" + index);
        Debug.Log("spriteList.Count::" + spriteList.Count);
        if (index == (spriteList.Count - 1))
        {
            nextButton.SetActive(false);
        }
        else
        {
            nextButton.SetActive(true);
        }
        prevButton.SetActive(true);
        selectedPlayer.sprite = spriteList[index];
    }
    public void showPrevPlayer()
    {

        index--;
        if (index == 0)
        {
            prevButton.SetActive(false);
        }
        else
        {
            prevButton.SetActive(true);
        }
        nextButton.SetActive(true);
        selectedPlayer.sprite = spriteList[index];

    }
    public void SelectPlayer()
    {
        selectPlayerMenu.SetActive(false);
        PlayerPrefs.GetInt("selectedPlayer", index);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
