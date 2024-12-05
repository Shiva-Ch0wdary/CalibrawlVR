using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationManager : MonoBehaviour
{
    public GameObject playerObj;

    public Transform[] teleportLocations;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TeleportToStage(int level)
    {
        int teleportIndex = level;
        if (teleportIndex == -1)
        {
            Debug.Log("Invalid Level");
            return;
        }
        playerObj.transform.position = teleportLocations[teleportIndex].position;
        playerObj.transform.rotation = teleportLocations[teleportIndex].rotation;
    }

}
