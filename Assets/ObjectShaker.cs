using UnityEngine;

public class ObjectShaker : MonoBehaviour
{
    // Shake parameters
    public float shakeIntensity = 0.5f; // Intensity of the shake
    public float shakeFrequency = 1f; // Frequency of the shake
    public bool shakeOnStart = false; // Option to shake on start

    private Vector3 originalPosition;
    private bool isShaking = false;

    void Start()
    {
        // Store the original position of the GameObject
        originalPosition = transform.localPosition;

        // Start shaking if shakeOnStart is true
        if (shakeOnStart)
        {
            StartShake(shakeIntensity, shakeFrequency);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isShaking)
        {
            // Shake the GameObject by modifying its localPosition
            float shakeOffsetX = Mathf.PerlinNoise(Time.time * shakeFrequency, 0f) * 2f - 1f;
            float shakeOffsetY = Mathf.PerlinNoise(0f, Time.time * shakeFrequency) * 2f - 1f;

            transform.localPosition = originalPosition + new Vector3(shakeOffsetX, shakeOffsetY, 0f) * shakeIntensity;
        }
    }

    // Public method to start the shake indefinitely
    public void StartShake(float intensity, float frequency)
    {
        shakeIntensity = intensity;
        shakeFrequency = frequency;
        isShaking = true;
    }

    // Public method to stop the shake
    public void StopShake()
    {
        isShaking = false;
        transform.localPosition = originalPosition;
    }
}
