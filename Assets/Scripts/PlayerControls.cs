using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    float xthrow;
    float ythrow;

    [SerializeField] float speedY = 1;
    [SerializeField] float speedX = 1;

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

    [SerializeField] float positionPitchFactor = -1f;
    [SerializeField] float controlPitchFactor = -10f;

    [SerializeField] float positionYawFactor = 1f;

    [SerializeField] float controlRollFactor = 1f;

    [SerializeField] GameObject[] lasers;

    float pitchDueToPosition;
    float pitchDueToControl;

    float yawDueToPosition;
    // Start is called before the first frame update
    void Start()
    {
       
       
    }

    // Update is called once per frame
    void Update()
    {
        ControlMovement();
        ControlRotation();
        ProcessFiring();
    }

    void ControlRotation()
    {
        pitchDueToPosition = transform.localRotation.y * positionPitchFactor;
        pitchDueToControl = ythrow * controlPitchFactor;
        pitch =  pitchDueToPosition + pitchDueToControl;
        yaw = transform.localPosition.x * positionYawFactor;
        roll = xthrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ControlMovement()
    {
        xthrow = Input.GetAxis("Horizontal");
        ythrow = Input.GetAxis("Vertical");

        xOffset = xthrow * speedX;
        yOffset = ythrow * speedY;
        rawPosX = transform.localPosition.x + xOffset;
        rawPosY = transform.localPosition.y + yOffset;

        xClampPos = Mathf.Clamp(rawPosX, -xRange, xRange);
        yClampPos = Mathf.Clamp(rawPosY, -yRange, yRange);

        transform.localPosition = new Vector3(xClampPos, yClampPos, transform.localPosition.z);
    }

    void ProcessFiring()
    {
        if (Input.GetButton("Fire1")) 
        {
            lasers[1].SetActive(true);
        }
        else
        {
            lasers[1].SetActive(false);
        }


        if (Input.GetButton("Fire2"))
        {
            lasers[0].SetActive(true);        
        }
        else
        {
            lasers[0].SetActive(false);
        }
        

    }

    void ActivateLasers()
    {
        foreach(GameObject laser in lasers)
        {
            laser.SetActive(true);
        }
    }
    void DeactivateLasers()
    {
        foreach (GameObject laser in lasers)
        {
            laser.SetActive(false);
        }
    }
}
