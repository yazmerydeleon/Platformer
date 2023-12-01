using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReSpawnPlayer()
    {
        Vector3 respawnPosition = new Vector3(0f, 0f, 0f);

        Instantiate(playerPrefab, respawnPosition, Quaternion.identity);
    }
}
