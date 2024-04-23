using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public float minimumLoadTime = 10f;  // Minimum time to display the loading screen

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        operation.allowSceneActivation = false; // Prevents the scene from activating immediately after it's loaded

        loadingScreen.SetActive(true);

        float timer = 0; // Track the time that has passed

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progress;

            // Increment the timer with the time passed since last frame
            timer += Time.deltaTime;

            // Check if the loading is complete and the minimum time has passed
            if (operation.progress >= 0.9f && timer >= minimumLoadTime)
            {
                operation.allowSceneActivation = true; // Allow scene activation if the minimum time has passed
            }

            yield return null;
        }
    }
}
