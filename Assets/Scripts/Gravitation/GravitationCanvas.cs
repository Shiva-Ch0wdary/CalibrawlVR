using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GravitationCanvas : MonoBehaviour
{

    public GameObject object1, object2;
    private Vector3 obj1Transform, obj2Transform;

    public TMP_Dropdown obj1Slider, obj2Slider;
    public TextMeshProUGUI obj1Text, obj2Text, forceText;

    private const float gravitationalConstant = 6.67430e-11f;

    // Start is called before the first frame update
    void Start()
    {
        obj1Transform = object1.transform.position;
        obj2Transform = object2.transform.position;
        obj1Slider.onValueChanged.AddListener((val) =>
        {
            object1.GetComponent<Rigidbody>().mass = val;
            obj1Text.text = "Mass M1 - " + (val + 1) + " kg";
        });

        obj2Slider.onValueChanged.AddListener((val) =>
        {
            object2.GetComponent<Rigidbody>().mass = val;
            obj2Text.text = "Mass M2 - " + (val + 1) + " kg";
        });

        ReCalculateForce();
    }

    public void ReCalculateForce()
    {
        float force = CalculateGravitationalForce(
            object1.GetComponent<Rigidbody>().mass,
            object2.GetComponent<Rigidbody>().mass,
            Vector3.Distance(object1.transform.position, object2.transform.position)
            );
        Debug.Log(force);
        forceText.text = "F = " + force.ToString("0.00E+00") + " Newtons";
    }

    float CalculateGravitationalForce(float mass1, float mass2, float distance)
    {
        return (gravitationalConstant * mass1 * mass2) / Mathf.Pow(distance, 2);
    }

    public void ResetApplePear()
    {
        object1.transform.position = obj1Transform;
        object2.transform.position = obj2Transform;
        //Rigidbody body = object1.GetComponent<Rigidbody>();
        //object1.GetComponent<Rigidbody>().AddForce(-body.velocity, ForceMode.VelocityChange);

        //body = object2.GetComponent<Rigidbody>();
        //object2.GetComponent<Rigidbody>().AddForce(-body.velocity, ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
