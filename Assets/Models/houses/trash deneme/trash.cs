using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trash : MonoBehaviour
{

    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider backRight;
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider backLeft;

    public float speed = 500f;

    private float currentSpeed = 0f;
   


    private void FixedUpdate()
    {
        currentSpeed = Input.GetAxis("Horizontal");

        frontRight.motorTorque = currentSpeed;
        frontLeft.motorTorque = currentSpeed;

    }


}
