using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogScript : MonoBehaviour
{
    [SerializeField] GameObject messageMenu;

    private void Start()
    {
        bool messageDisplayed = PlayerPrefs.GetInt("messageDisplayed", 0) == 1 ? true : false;

        if (!messageDisplayed)
        {

            messageMenu.SetActive(true);
        }
    }
    public void messageConfirm()
    {
        PlayerPrefs.SetInt("messageDisplayed", 1);
        messageMenu.SetActive(false);
    }
}
