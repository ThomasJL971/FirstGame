using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class chargement2 : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;

    void OnTriggerEnter()
    {
        SceneManager.LoadScene("Dragon");

    }

    IEnumerator LoadAsync(string lave)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("Dragon");

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            slider.value = progress;

            yield return null;
        }
    }
}
