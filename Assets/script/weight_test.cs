using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Rigidbody))]
public class WeightedGrabPhysics : XRGrabInteractable
{
    public float weightMultiplier = 40f; // Adjusts difficulty of lifting heavy objects

    private Rigidbody rb;
    private Transform handTransform;
    private bool isGrabbed = false;

    protected override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.isKinematic = false;

        selectEntered.AddListener(OnGrab);
        selectExited.AddListener(OnRelease);
    }

    private void OnDestroy()
    {
        selectEntered.RemoveListener(OnGrab);
        selectExited.RemoveListener(OnRelease);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        isGrabbed = true;
        handTransform = args.interactorObject.transform;
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        isGrabbed = false;
        handTransform = null;
    }

    private void FixedUpdate()
    {
        if (isGrabbed && handTransform != null)
        {
            // Calculate direction & distance
            Vector3 direction = handTransform.position - transform.position;

            // Calculate lifting force based on object's mass
            float liftSpeed = weightMultiplier / rb.mass; // Heavier mass = slower lifting

            // Apply smooth lifting movement
            rb.velocity = direction * liftSpeed;
        }
    }
}
