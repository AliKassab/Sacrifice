using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    float xthrow;
    float ythrow;
    [Header("Ship's Speed")]
    [SerializeField] float speedY = 1;
    [SerializeField] float speedX = 1;
    [Header("Movement Range")]
    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 5f;

    float xClampPos;
    float yClampPos;
    float xOffset;
    float yOffset;
    float rawPosX;
    float rawPosY;

    float pitch = 0f;
    float yaw = 0f;
    float roll = 0f;
    [Header("Tilt Factor")]
    [SerializeField] float positionPitchFactor = -1f;
    [SerializeField] float controlPitchFactor = -10f;

    [SerializeField] float positionYawFactor = 1f;

    [SerializeField] float controlRollFactor = 1f;

    [SerializeField] GameObject[] lasers;

    float pitchDueToPosition;
    float pitchDueToControl;

    float yawDueToPosition;

    // Update is called once per frame
    void Update()
    {
        ControlMovement();
        ControlRotation();
        ProcessFiring();
    }

    void ControlRotation()
    {
        TiltProcessing();

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void TiltProcessing()
    {
        pitchDueToPosition = transform.localRotation.y * positionPitchFactor;
        pitchDueToControl = ythrow * controlPitchFactor;
        pitch = pitchDueToPosition + pitchDueToControl;
        yaw = transform.localPosition.x * positionYawFactor;
        roll = xthrow * controlRollFactor;
    }

    private void ControlMovement()
    {
        xthrow = Input.GetAxis("Horizontal");
        ythrow = Input.GetAxis("Vertical");

        PositionProcessing();

        transform.localPosition = new Vector3(xClampPos, yClampPos, transform.localPosition.z);
    }

    private void PositionProcessing()
    {
        xOffset = xthrow * speedX;
        yOffset = ythrow * speedY;
        rawPosX = transform.localPosition.x + xOffset;
        rawPosY = transform.localPosition.y + yOffset;


        xClampPos = Mathf.Clamp(rawPosX, -xRange, xRange);
        yClampPos = Mathf.Clamp(rawPosY, -yRange, yRange);
    }

    void ProcessFiring()
    {
        if (Input.GetButton("Fire1")) 
        {
            ActivateLasers(1, true);
        }
        else
        {
            ActivateLasers(1, false);
        }
        if (Input.GetButton("Fire2"))
        {
            ActivateLasers(0, true);
        }
        else
        {
            ActivateLasers(0, false);
        }
        
    }

    void ActivateLasers(int index, bool active)
    {
        var emissionModule = lasers[index].GetComponent<ParticleSystem>().emission;
        emissionModule.enabled = active;
    }
}
