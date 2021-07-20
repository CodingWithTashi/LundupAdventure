using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class GameOverScript : MonoBehaviour, IUnityAdsListener
{
    public GameObject gameObject;
    GameMaster gm;
    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        Advertisement.AddListener(this);
    }
    public void GoToHome(int sceneID)
    {
        gm.lastCheckPointPos = gm.originalPosition;
        Time.timeScale = 1f;
        GameController.playerLifeCount = 3;
        SceneManager.LoadScene(sceneID);
        gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        Debug.Log(SceneManager.GetActiveScene().buildIndex + 1);
        if ((SceneManager.GetActiveScene().buildIndex+1) % 2 == 0)
        {
            AdsManager.PlayIntertitailAds();
        }
        gm.lastCheckPointPos = gm.originalPosition;
        Time.timeScale = 1f;
        GameController.playerLifeCount = 3;
        gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
  
    public static void playRewardsAds()
    {
        Debug.Log("INITTTTT");
        if (Advertisement.IsReady(AdsManager.rewardId))
        {
            Advertisement.Show(AdsManager.rewardId);
        }
        else
        {
            Debug.Log("Error loading reward ads");
        }
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsDidFinish(string surfacingId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            Debug.LogWarning("OnUnityAdsDidFinish");
            Time.timeScale = 1f;
            GameController.playerLifeCount = 3;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //gameObject.SetActive(false);
        }
        else if (showResult == ShowResult.Skipped)
        {
            // Do not reward the user for skipping the ad.
            Debug.LogWarning("OnUnityAdsDidFinish Skip");
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
        }
    }

    public void OnUnityAdsReady(string surfacingId)
    {
        // If the ready Ad Unit or legacy Placement is rewarded, show the ad:
        if (surfacingId == AdsManager.rewardId)
        {
            // Optional actions to take when theAd Unit or legacy Placement becomes ready (for example, enable the rewarded ads button)
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string surfacingId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }

    // When the object that subscribes to ad events is destroyed, remove the listener:
    public void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }
}
