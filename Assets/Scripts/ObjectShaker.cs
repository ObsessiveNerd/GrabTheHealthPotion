using UnityEngine;

public class ObjectShaker : MonoBehaviour 
{
    float shakeDuration = 1f; // Duration of the shake
    float shakeMagnitude = 20f; // Magnitude of the shake

    private Vector3 originalPosition; // Original position of the object
    private float shakeTimer = 0f; // Timer for tracking shake duration

    void Start()
    {
        originalPosition = transform.position; // Store the original position
    }

    void Update()
    {
        if (shakeTimer > 0)
        {
            // Generate random offset for the shake
            Vector3 shakeOffset = Random.insideUnitSphere * shakeMagnitude;

            // Apply the shake offset to the object's position
            transform.position = originalPosition + shakeOffset;

            // Decrement the timer
            shakeTimer -= Time.deltaTime;
        }
        else
        {
            // Reset the object's position to its original position
            transform.position = originalPosition;
        }
    }

    public void Shake()
    {
        // Start the shake by setting the timer
        shakeTimer = shakeDuration;
    }
}