using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loading : MonoBehaviour
{
    public GameObject loadingscreen;
    public Slider slider;
    void Start()
    {
        loadingscreen.SetActive(false);
    }
    public void LoadLevel(int sceneindex)
    {
        StartCoroutine(LoadAsynchronously(sceneindex));
    }
    IEnumerator LoadAsynchronously(int sceneindex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneindex);
        loadingscreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress * 10);
            slider.value = progress;
            yield return null;
            Debug.Log(Mathf.Clamp01(operation.progress));
        }
    }
    // Start is called before the first frame update

}