using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Chargement : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;

    void OnTriggerEnter()
    {
        SceneManager.LoadScene("SampleScene");
        
    }

    IEnumerator LoadAsync(string SampleScene)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("SampleScene");

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            slider.value = progress;

            yield return null;
        }
    }
}
