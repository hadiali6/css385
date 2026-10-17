using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float baseSpeed = 15.0f;
    public float speedRange = 10.0f; 
    private float currentSpeed;

    public float rotationSpeed = 60.0f;
    public float maxPitchUpAngle = 85.0f;
    public float maxPitchDownAngle = 85.0f;
    private float currentPitch = 0.0f;

    public float verticalInput;
    public float horizontalInput;

    void FixedUpdate()
    {
        verticalInput = Input.GetAxis("Vertical");     
        horizontalInput = Input.GetAxis("Horizontal"); 

        currentSpeed = baseSpeed + (horizontalInput * speedRange);
        transform.Translate(Vector3.forward * Time.fixedDeltaTime * currentSpeed);

        currentPitch += verticalInput * rotationSpeed * Time.fixedDeltaTime;

        currentPitch = Mathf.Clamp(currentPitch, -maxPitchDownAngle, maxPitchUpAngle);

        transform.localEulerAngles = new Vector3(-currentPitch, transform.localEulerAngles.y, transform.localEulerAngles.z);
    }
}
