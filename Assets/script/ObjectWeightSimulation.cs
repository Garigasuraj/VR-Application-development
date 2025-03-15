using UnityEngine;

public class ObjectWeightSimulation : MonoBehaviour
{
    public float weightMultiplier = 1.5f; // Adjust weight perception
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Get the current velocity
        Vector3 velocity = rb.velocity;

        // Separate the vertical (gravity) and horizontal movement
        Vector3 horizontalVelocity = new Vector3(velocity.x, 0, velocity.z);
        float verticalVelocity = velocity.y;

        // Apply weight damping ONLY to the horizontal movement
        horizontalVelocity *= 1 / weightMultiplier;

        // Reapply vertical velocity (gravity effect remains unchanged)
        rb.velocity = new Vector3(horizontalVelocity.x, verticalVelocity, horizontalVelocity.z);
    }
}
