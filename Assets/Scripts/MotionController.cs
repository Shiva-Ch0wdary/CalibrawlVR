using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionController : MonoBehaviour
{
    // Start is called before the first frame update
    public float startX=-3.0f;
    public float endX=0f;
    public string flag = "x";
    
    private float speed;
    private float newTheta;
    //private bool movingRight = false;


    void Start()
    {
        newTheta = Random.Range(0f, Mathf.PI);
        speed = Random.Range(0.5f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        newTheta += speed * Time.deltaTime;
        if (flag == "x")
        {
            transform.localPosition = new Vector3((Mathf.Abs(endX) - Mathf.Abs(startX)) / 2 + Mathf.Cos(newTheta) * (endX - startX) / 2, transform.localPosition.y, transform.localPosition.z);
        }else if (flag == "z")
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, (Mathf.Abs(endX) - Mathf.Abs(startX)) / 2 + Mathf.Cos(newTheta) * (endX - startX) / 2);
        }else if (flag == "y")
        {
            transform.localPosition = new Vector3(transform.localPosition.x, (Mathf.Abs(endX) - Mathf.Abs(startX)) / 2 + Mathf.Cos(newTheta) * (endX - startX) / 2, transform.localPosition.z);
        } 
    }
}
