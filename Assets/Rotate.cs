using UnityEngine;

public class InfiniteRotation : MonoBehaviour
{
    public float rotationSpeed = 30f;

    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}
