using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandStretchController : MonoBehaviour
{
    public XRDirectInteractor handInteractor; // Assign Left or Right XRDirectInteractor here
    public Transform controllerTransform;     // Assign Left or Right Controller Transform here

    private Vector3 originalLocalPosition;

    void Start()
    {
        originalLocalPosition = transform.localPosition;
    }

    void Update()
    {
        if (handInteractor.hasSelection)
        {
            var grabbedObject = handInteractor.interactablesSelected[0].transform;
            var weightedGrab = grabbedObject.GetComponent<WeightedGrab>();

            if (weightedGrab != null)
            {
                float massFactor = weightedGrab.objectMass / 5f;
                Vector3 offsetDirection = (grabbedObject.position - controllerTransform.position).normalized;

                // Adjust stretch multiplier as needed (0.02f is example sensitivity)
                float stretchDistance = Mathf.Clamp(massFactor * 0.02f, 0f, 0.3f);

                transform.position = controllerTransform.position + offsetDirection * stretchDistance;
            }
        }
        else
        {
            // Reset position when not holding objects
            transform.localPosition = Vector3.Lerp(transform.localPosition, originalLocalPosition, Time.deltaTime * 10f);
        }
    }
}
