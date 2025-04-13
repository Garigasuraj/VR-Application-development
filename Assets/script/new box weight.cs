using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newboxweight : MonoBehaviour
{
    public float bigboxWeight = 0f;

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody obj = other.GetComponent<Rigidbody>();

        if (obj != null)
        {
            Debug.Log("The mass: " + obj.mass);
            bigboxWeight += obj.mass;
            Debug.Log("Object added. New box weight: " + bigboxWeight);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Rigidbody obj = other.GetComponent<Rigidbody>();

        if (obj != null)
        {
            bigboxWeight -= obj.mass;
            Debug.Log("Object removed. New box weight: " + bigboxWeight);
        }
    }
}
