using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus; // Oculus SDK reference

public class weight_test : MonoBehaviour
{
    public Rigidbody box10kg;  // Assign the 10kg object
    public Rigidbody box30kg;  // Assign the 30kg object

    public float forceAmount = 500f;  // Adjust force to see differences

    void Update()
    {
        // Check if the user presses the trigger button on the right-hand controller
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            // Apply the same force to both objects
            box10kg.AddForce(Vector3.forward * forceAmount, ForceMode.Impulse);
            box30kg.AddForce(Vector3.forward * forceAmount, ForceMode.Impulse);

            Debug.Log("Oculus Trigger Pressed! Force Applied to Objects.");
        }
    }
}
