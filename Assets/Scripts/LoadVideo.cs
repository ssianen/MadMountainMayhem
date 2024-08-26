using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement; // To manage scene transitions
using System.Collections;
public class LoadVideo : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Reference to the VideoPlayer component
    public GameObject loadingScreen; // Reference to the loading screen GameObject
    void Start()
    {
        StartCoroutine(LoadVideoScene());
    }
    IEnumerator LoadVideoScene()
    {
        // Enable loading screen
        loadingScreen.SetActive(true);

        // Start preparing the video
        videoPlayer.Prepare();
        
        // Wait until the video is prepared
        while (!videoPlayer.isPrepared)
        {
            yield return null; // Wait for the next frame
        }

        // Disable loading screen after the video is ready
        loadingScreen.SetActive(false);

        // Start playing the video
        videoPlayer.Play();
    }
}
