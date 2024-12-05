using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRestriction : OVRGrabbable
{
    private Vector3 startPos;
    
    // Start is called before the first frame update
    new void Start()
    {
        startPos = transform.position;
    }

    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        base.GrabBegin(hand, grabPoint);

        startPos = transform.position;
    }

    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        base.GrabEnd(Vector3.zero,Vector3.zero);
    }

    void Update()
    {
        Debug.Log("grabbed");
        if (isGrabbed)
        {
            // Restrict Y-axis movement during grab
            Vector3 newPosition = transform.position;
            newPosition.y = startPos.y; // Lock the Y position
            transform.position = newPosition;
        }
    }

    // Update is called once per frame
    
}
