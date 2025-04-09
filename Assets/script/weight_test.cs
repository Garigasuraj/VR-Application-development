using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Rigidbody))]
public class WeightedGrabPhysics : XRGrabInteractable
{
    public float weightMultiplier = 30f; // Adjusts difficulty of lifting heavy objects

    [SerializeField] private Weight updated_weight;

    public Transform leftAttachTransform;
    public Transform rightAttachTransform;

    private Rigidbody rb;
    private Transform handTransform;
    private bool isGrabbed = false;
    private Vector3 grabOffset;

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

        // Detect closer handle at grab time
        float distToLeft = Vector3.Distance(handTransform.position, leftAttachTransform.position);
        float distToRight = Vector3.Distance(handTransform.position, rightAttachTransform.position);

        attachTransform = (distToLeft < distToRight) ? leftAttachTransform : rightAttachTransform;
        base.attachTransform = attachTransform;

        // Calculate grab offset
        grabOffset = transform.position - handTransform.position;
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
            Vector3 targetPosition = handTransform.position + grabOffset;
            Vector3 direction = targetPosition - transform.position;
            float liftSpeed = (weightMultiplier + updated_weight.boxWeight) / rb.mass;

            Debug.Log("liftspeed: " + liftSpeed);

            rb.velocity = direction * liftSpeed;
        }
    }

}

