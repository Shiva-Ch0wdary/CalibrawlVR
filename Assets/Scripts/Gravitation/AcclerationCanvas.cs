using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AcclerationCanvas : MonoBehaviour
{
    public GameObject apple;
    public GameObject pear;
    private Vector3 appleTransform, pearTransform;

    public TMP_Dropdown m1Slider, m2Slider;
    public TextMeshProUGUI m1Text, m2Text;
    public TextMeshProUGUI m1Time, m2Time;


    // Start is called before the first frame update
    void Start()
    {
        appleTransform = apple.transform.position;
        pearTransform = pear.transform.position;
        m1Slider.onValueChanged.AddListener((val) =>
        {
            apple.GetComponent<Rigidbody>().mass = val;
            m1Text.text = "Mass M1 - " + (val + 1) + " kg";
        });

        m2Slider.onValueChanged.AddListener((val) =>
        {
            pear.GetComponent<Rigidbody>().mass = val;
            m2Text.text = "Mass M2 - " + (val + 5) + " kg";
        });
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResetApplePear()
    {
        apple.transform.position = appleTransform;
        pear.transform.position = pearTransform;

        Rigidbody body = apple.GetComponent<Rigidbody>();
        apple.GetComponent<Rigidbody>().AddForce(-body.velocity, ForceMode.VelocityChange);

        body = pear.GetComponent<Rigidbody>();
        pear.GetComponent<Rigidbody>().AddForce(-body.velocity, ForceMode.VelocityChange);
    }

    public void InfoCanvas()
    {
        TimeDiff appDiff = apple.GetComponent<BallController>().diff;

        TimeDiff pearDiff = pear.GetComponent<BallController>().diff;

        Debug.Log(appDiff.end.Subtract(appDiff.start).Seconds);
        Debug.Log(pearDiff.end.Subtract(pearDiff.start).Seconds);

        m1Time.text = appDiff.end.Subtract(appDiff.start).Seconds + " s";
        m2Time.text = pearDiff.end.Subtract(pearDiff.start).Seconds + " s";
    }
}
