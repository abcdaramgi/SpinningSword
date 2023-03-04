using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float targetRotation = 180f; // the desired z-axis rotation
    public float torque = 10f; // the torque applied to the object
    public float damping = 2f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float currentRotation = transform.rotation.eulerAngles.z;

        if (currentRotation > targetRotation)
        {
            // rotate counterclockwise
            rb.AddTorque(-torque);
        }
        else if (currentRotation < targetRotation)
        {
            // rotate clockwise
            rb.AddTorque(torque);
        }

        // apply rotation resistance
        rb.angularVelocity *= Mathf.Clamp01(1f - Time.fixedDeltaTime * damping);
    }

    public void StartRotation()
    {
        // reset the rigidbody's angular velocity
        rb.angularVelocity = 0f;

        // trigger the rotation code
        StartCoroutine(RotateTowardsTarget());
    }

    private IEnumerator RotateTowardsTarget()
    {
        while (Mathf.Abs(transform.rotation.eulerAngles.z - targetRotation) > 0.1f)
        {
            yield return null;
        }
        rb.angularVelocity = 0f;
    }
}
