using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;

public class ThrowListener : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Grabbable grabbable;

    [SerializeField]
    TrailRenderer trail;
    bool _initFlag;

    void Start()
    {
        _initFlag = false;
        trail.emitting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(grabbable.SelectingPointsCount == 0)
        {
            //trail.Clear();
            if(_initFlag) trail.emitting = true;
        }
        else
        {
            _initFlag = true;
            trail.emitting = false;
            trail.Clear();
        }
    }
}
