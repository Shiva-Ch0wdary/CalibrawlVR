using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageTeleport : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject playerObj;

    public Transform[] teleportLocations;


    void Start()
    {
        
    }

    public void TeleportToStage(int level)
    {
        int teleportIndex = level;
        if(teleportIndex == -1)
        {
            Debug.Log("Invalid Level");
            return;
        }
        playerObj.transform.position = teleportLocations[teleportIndex].position;
        playerObj.transform.rotation = teleportLocations[teleportIndex].rotation;
    }
}
