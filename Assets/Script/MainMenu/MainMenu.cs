using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class MainMenu : MonoBehaviour
{
    Toggle toggle;
    [SerializeField] AudioSource audio;

    string subject = "Tibetan Game (Lundup Journey)";
    string body = "https://play.google.com/store/apps/details?id=com.webroid.smashy.cat.kitty";
    // Start is called before the first frame update
    private void Start()
    {
        
        toggle = GetComponent<Toggle>();
        //audio = GetComponent<AudioSource>();
        
        int isMuted = PlayerPrefs.GetInt("isMuted", 0);
        //if it is muted
        if (isMuted == 1)
        {
            toggle.isOn = true;
            audio.mute = true;
        }
        else
        {
            toggle.isOn = false;
            audio.mute = false;

        }
        audio.Play();
        
       
       

    }
    public void play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    public void gotToLevelSelection()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
  

    public void exitGame()
    {
        Application.Quit();
    }
    public void shareGame()
    {
        ShareAndroidText();
    }
    public void rateUs()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.KharagEdition.TibetanGameLundupJourney");
    }
    public void muteGame(bool mute)
    {
        Debug.Log(toggle.isOn);
        //if sound is muted
        if (toggle.isOn)
        {
            PlayerPrefs.SetInt("isMuted", 1);
            audio.mute = true;
        }
        else
        {
            PlayerPrefs.SetInt("isMuted", 0);
            audio.mute = false;
        }
    }

    void ShareAndroidText()
    {
        //execute the below lines if being run on a Android device
        //Reference of AndroidJavaClass class for intent
        AndroidJavaClass intentClass = new AndroidJavaClass ("android.content.Intent");
        //Reference of AndroidJavaObject class for intent
        AndroidJavaObject intentObject = new AndroidJavaObject ("android.content.Intent");
        //call setAction method of the Intent object created
        intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
        //set the type of sharing that is happening
        intentObject.Call<AndroidJavaObject>("setType", "text/plain");
        //add data to be passed to the other activity i.e., the data to be sent
        intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), "Tibetan Game(Lundup Adventure)");
        intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), "https://play.google.com/store/apps/details?id=com.codingwithtashi.dailyprayer");
        //get the current activity
        AndroidJavaClass unity = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
        //start the activity by sending the intent data
        currentActivity.Call ("startActivity", intentObject);


    }
}
