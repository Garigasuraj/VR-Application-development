using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Rigidbody))]
public class WeightedGrab : XRGrabInteractable
{
    public float objectMass = 1f; // Set this in inspector (1, 10, 50, 100)
    public float stretchThreshold = 0.3f; // Distance threshold to auto-release

    private Rigidbody rb;
    private Transform originalAttachTransform;
    private Transform controllerTransform;
    private bool isGrabbed = false;

    protected override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody>();
        rb.mass = objectMass;
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        // Setup attachment transform
        originalAttachTransform = new GameObject("AttachTransform").transform;
        originalAttachTransform.SetParent(transform);
        attachTransform = originalAttachTransform;

        selectEntered.AddListener(OnGrabbed);
        selectExited.AddListener(OnReleased);
    }

    private void OnDestroy()
    {
        selectEntered.RemoveListener(OnGrabbed);
        selectExited.RemoveListener(OnReleased);
    }

    private void OnGrabbed(SelectEnterEventArgs args)
    {
        isGrabbed = true;
        controllerTransform = args.interactorObject.transform;
        rb.isKinematic = false; // Allow physics to affect the object
    }

    private void OnReleased(SelectExitEventArgs args)
    {
        isGrabbed = false;
        controllerTransform = null;
        ResetAttachTransform();
        rb.isKinematic = false; // Ensure gravity works after release
    }

    void FixedUpdate()
    {
        if (isGrabbed && controllerTransform != null)
        {
            float distance = Vector3.Distance(controllerTransform.position, transform.position);

            // Adjust attachment point based on mass
            Vector3 offsetDirection = (controllerTransform.position - transform.position).normalized;
            float stretchAmount = Mathf.Clamp((objectMass / 10f) * 0.02f, 0, stretchThreshold);
            attachTransform.position = controllerTransform.position - offsetDirection * stretchAmount;

            // Auto-release if too stretched
            if (distance > stretchThreshold)
            {
                interactionManager.SelectExit(interactorsSelecting[0], this);
            }
        }
    }

    private void ResetAttachTransform()
    {
        attachTransform.localPosition = Vector3.zero;
        attachTransform.localRotation = Quaternion.identity;
    }
}