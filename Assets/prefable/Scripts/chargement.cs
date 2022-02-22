using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class chargement : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;

    void OnTriggerEnter()
    {
        SceneManager.LoadScene("CoeurMontagne");
        
    }

    IEnumerator LoadAsync(string CoeurMontagne)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("CoeurMontagne");

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            slider.value = progress;

            yield return null;
        }
    }
}
