using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class scenemanager : MonoBehaviour
{
    public Text IQ;
 
    public int IQvalue;
    
    public GameObject mainmenu;
   
    public GameObject othergames;


    // Start is called before the first frame update
    private void Start()
    {
        
       
        mainmenu.SetActive(true);
        othergames.SetActive(false);
        IQvalue = PlayerPrefs.GetInt("score", 0);
      
        IQ.text = IQvalue.ToString();

       
    }
    // Update is called once per frame
    public void looadscene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void FixedUpdate()
    {
        IQvalue = PlayerPrefs.GetInt("score", 0);

        IQ.text = IQvalue.ToString();

    }

    public void enterothergames()
    {
        mainmenu.SetActive(false);
        othergames.SetActive(true);
    }
    public void exitother()
    {
        mainmenu.SetActive(true);
        othergames.SetActive(false);
    }
  
   
    public void RateUs()
    {
#if UNITY_ANDROID
Application.OpenURL("market://details?id=com.Ramic.BallDestroyer");
#endif


    }
}
