using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TempPortal : MonoBehaviour
{
    private float timeDelay = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(LoadNextScene());        
    }

    IEnumerator LoadNextScene() 
    {
        yield return new WaitForSecondsRealtime(timeDelay);       
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        int nextSceneIndex = currentSceneIndex + 1;

        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
