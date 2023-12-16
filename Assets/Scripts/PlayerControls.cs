using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{
    #region Editor Variables
    [Header("Ship's Speed")]
    [SerializeField] float speedY = 1;
    [SerializeField] float speedX = 1;

    [Header("Movement Range")]
    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 5f;

    [Header("Tilt Factor")]
    [SerializeField] float positionPitchFactor = -1f;
    [SerializeField] float controlPitchFactor = -10f;

    [SerializeField] float positionYawFactor = 1f;

    [SerializeField] float controlRollFactor = 1f;

    [Header("Laser")]
    [SerializeField] GameObject[] lasers;
    #endregion

    #region Private Variables
    float xthrow;
    float ythrow;
    float xClampPos;
    float yClampPos;
    float xOffset;
    float yOffset;
    float rawPosX;
    float rawPosY;

    float pitch = 0f;
    float yaw = 0f;
    float roll = 0f;
    
    float pitchDueToPosition;
    float pitchDueToControl;

    float yawDueToPosition;
    #endregion

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(0);

        ControlMovement();
        ControlRotation();
        ProcessFiring();
    }
    private void ControlMovement()
    {
        xthrow = Input.GetAxis("Horizontal");
        ythrow = Input.GetAxis("Vertical");

        PositionProcessing();

        transform.localPosition = new Vector3(xClampPos, yClampPos, transform.localPosition.z);
    }

    void ControlRotation()
    {
        TiltProcessing();

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessFiring()
    {
        ActivateLasers(1, Input.GetButton("Fire1"));
        ActivateLasers(0, Input.GetButton("Fire2"));
    }

    private void TiltProcessing()
    {
        pitchDueToPosition = transform.localRotation.y * positionPitchFactor;
        pitchDueToControl = ythrow * controlPitchFactor;
        pitch = pitchDueToPosition + pitchDueToControl;
        yaw = transform.localPosition.x * positionYawFactor;
        roll = xthrow * controlRollFactor;
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

    void ActivateLasers(int index, bool active)
    {
        var emissionModule = lasers[index].GetComponent<ParticleSystem>().emission;
        emissionModule.enabled = active;
    }
}
