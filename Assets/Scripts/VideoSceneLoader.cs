using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement; // To manage scene transitions
using System.Collections;
public class VideoSceneLoader : MonoBehaviour
{
    public string videoSceneName; // Name of the scene to load with the video

    public void StartVideoScene()
    {
        StartCoroutine(LoadVideoSceneAsync());
    }

    IEnumerator LoadVideoSceneAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(videoSceneName);
        asyncLoad.allowSceneActivation = false; // Prevent scene from activating immediately

        // Wait until the scene is loaded
        while (!asyncLoad.isDone)
        {
            if (asyncLoad.progress >= 0.9f)
            {
                // If the video is prepared and the scene is almost loaded, activate the scene
                asyncLoad.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
