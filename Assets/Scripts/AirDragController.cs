using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirDragController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    private readonly float airDragCoefficient = 0.1f;
    private Vector3 airDragDirection = Vector3.back;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (rb.velocity != Vector3.zero)
        {
            Vector3 airDrag = -airDragCoefficient * rb.velocity.magnitude * airDragDirection;
            rb.AddForce(airDrag);
        }
    }

    
    void Update()
    {

    }
}
