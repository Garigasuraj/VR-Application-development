using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weight : MonoBehaviour
{
    public float boxWeight = 0f;


    private void OnTriggerEnter(Collider other)
    {
        Rigidbody obj = other.GetComponent<Rigidbody>();

      

        if (obj != null)
        {
            Debug.Log("The mass: " + obj.mass);
            boxWeight += obj.mass;
            Debug.Log("Object added. New box weight: " + boxWeight);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Rigidbody obj = other.GetComponent<Rigidbody>();

        if (obj != null)
        {
            boxWeight -= obj.mass;
            Debug.Log("Object removed. New box weight: " + boxWeight);
        }
    }
}
