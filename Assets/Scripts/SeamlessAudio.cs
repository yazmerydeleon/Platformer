using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeamlessAudio : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] musicObjects = GameObject.FindGameObjectsWithTag("Game Music");
        if(musicObjects.Length > 1)
        {
            Destroy(gameObject);
        }
        else 
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    
}
