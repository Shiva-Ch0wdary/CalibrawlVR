using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VerticalMotionController : MonoBehaviour
{
    public string flag;

    private float moveDistance;
    private float moveSpeed;
    private Vector3 initialPosition;
    private bool movingForward=true;

    void Start()
    {
        initialPosition = transform.position;
        moveSpeed = Random.Range(0f, 2f);
        moveDistance = 3;
    }

    void Update()
    {
        Vector3 targetPos = movingForward ? initialPosition + Vector3.forward * moveDistance : initialPosition;
        
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

        if (transform.position == targetPos)
        {
            movingForward = !movingForward;
        }
    }
}
