using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemCollector : MonoBehaviour
{
    private int fruitCount = 0;
    [SerializeField] private Text fruitText;
    [SerializeField] private Text totalFruitText;
    [SerializeField] private AudioSource collectionSoundEffect;
    bool isMuted = false;
    private void Start()
    {
        isMuted = PlayerPrefs.GetInt("isMuted", 0) == 1 ? true : false;
        totalFruitText.text = "ཤིང་ཏོག་ཁྱོན་སྡོམ། ཿ " + GetNumberInTibetan(PlayerPrefs.GetInt("totalFruit", 0));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Cherry":
                {
                    destroyFruitsAndReturnValue(collision, "ཅེ་རི་ ཿ ");
                    break;
                }
            case "Banana":
                {
                    destroyFruitsAndReturnValue(collision, "ངང་ལག།་ ཿ ");
                    break;
                }
            case "Apple":
                {
                    destroyFruitsAndReturnValue(collision, "ཀུ་ཤུ། ཿ ");
                    break;
                }
            case "Kiwi":
                {
                    destroyFruitsAndReturnValue(collision, "སྤྲེལ་ཁམ། ཿ ");
                    break;
                }
            case "Melon":
                {
                    destroyFruitsAndReturnValue(collision, "ཆུ་ག་གོན། ཿ ");
                    break;
                }
            case "Orange":
                {
                    destroyFruitsAndReturnValue(collision, "ཚ་ལུ་མ། ཿ ");
                    break;
                }
            case "PineApple":
                {
                    destroyFruitsAndReturnValue(collision, "ཐང་འབྲས། ཿ ");
                    break;
                }
            case "Straw":
                {
                    destroyFruitsAndReturnValue(collision, "སེ་འབྲུ་དམར་པོ། ཿ ");
                    break;
                }
        }

       
    }

    private void destroyFruitsAndReturnValue(Collider2D collision,String title)
    {
        if (!isMuted)
        {
            collectionSoundEffect.Play();
        }

        Destroy(collision.gameObject);
        fruitCount++;
        int total = PlayerPrefs.GetInt("totalFruit", 0) + 1;
        PlayerPrefs.SetInt("totalFruit", total);
        fruitText.text = title + GetNumberInTibetan(fruitCount);
        totalFruitText.text = "ཤིང་ཏོག་ཁྱོན་སྡོམ། ཿ " + GetNumberInTibetan(total);
    }

    private string GetNumberInTibetan(int cherries)
    {
        string returnValue = "";
        String cherryText = cherries.ToString();
        for(int i=0;i<cherryText.Length; i++)
        {
            char temp = cherryText[i];
            switch (temp)
            {
                case '0':
                    {
                        returnValue+="༠";
                        break;
                    }
                case '1':
                    {
                        returnValue += "༡";
                        break;
                    }
                case '2':
                    {
                        returnValue += "༢";
                        break;
                    }
                case '3':
                    {
                        returnValue += "༣";
                        break;
                    }
                case '4':
                    {
                        returnValue += "༤";
                        break;
                    }
                case '5':
                    {
                        returnValue += "༥";
                        break;
                    }
                case '6':
                    {
                        returnValue += "༦";
                        break;
                    }
                case '7':
                    {
                        returnValue += "༧";
                        break;
                    }
                case '8':
                    {
                        returnValue += "༨";
                        break;
                    }
                case '9':
                    {
                        returnValue += "༩";
                        break;
                    }
            }
        }
        return returnValue;


    }
}
