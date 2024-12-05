using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public class TimeDiff
{
    public System.DateTime start, end;
}

public enum Ball
{
    PEAR,APPLE,OBJECT
}

public class BallController : MonoBehaviour
{
    public Grabbable grabbable;
    
    public TimeDiff diff;
    public bool thrown;

    public Ball flag;

    // Start is called before the first frame update
    void Start()
    {
        thrown= false;
    }

    // Update is called once per frame
    void Update()
    {
        if(grabbable.SelectingPointsCount == 0)
        {
            diff = new TimeDiff
            {
                start = System.DateTime.Now
            };
        }
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Default")
        {
            thrown = true;
            diff.end = System.DateTime.Now;
        }
    }
}
