using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipMovement : MonoBehaviour
{
    [SerializeField]private bool _isMoving = true;
    [SerializeField]private float _controlSpeed = 20f;

    [SerializeField] private float _xRange = 9.5f;
    [SerializeField] private float _yRange = 9f;
    [SerializeField] private float _yRangeDownOffset = 5f;

    [SerializeField] private float _positionPitchFactor = -2f;
    [SerializeField] private float _controlPitchFactor = -10f;
    [SerializeField] private float _positionYawFactor = 2f;


    [SerializeField] private float _controlRollFactor = -20f;

    public float xThrow, yThrow;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        ProcessMovement();
        ProcessRotation();
 
    }

    private void ProcessMovement()
    {
        if(_isMoving)
        {
            xThrow = Input.GetAxis("Horizontal");
            yThrow = Input.GetAxis("Vertical");

            float xOffset = xThrow * Time.deltaTime * _controlSpeed;
            float rawXPos = transform.localPosition.x + xOffset;
            float ClampedXPos = Mathf.Clamp(rawXPos, -_xRange, _xRange);

            float yOffset = yThrow * Time.deltaTime * _controlSpeed;
            float rawYPos = transform.localPosition.y + yOffset;
            float ClampedYPos = Mathf.Clamp(rawYPos, -_xRange + _yRangeDownOffset, _yRange);

            transform.localPosition = new Vector3(ClampedXPos, ClampedYPos, transform.localPosition.z);
        }
    }


    private void ProcessRotation()
    {
        //Pitch
        float pitchDueToPosition = transform.localPosition.y * _positionPitchFactor;
        float pitctDueToControlThrow = yThrow * _controlPitchFactor;

        float pitch = pitchDueToPosition + pitctDueToControlThrow;

        // Yaw
        float yawDueToPosition = transform.localPosition.x * _positionYawFactor;

        float yaw = yawDueToPosition;

        // Roll
        float rollDueToControlThrow = xThrow * _controlRollFactor;

        float roll = rollDueToControlThrow;


        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
}
