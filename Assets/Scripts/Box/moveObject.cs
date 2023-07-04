using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveObject : MonoBehaviour
{
    public float pushForce = 1;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody _rigid = hit.collider.attachedRigidbody;

        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (_rigid != null)
            {
                Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
                forceDirection.y = 0;
                forceDirection.Normalize();
                
                _rigid.AddForceAtPosition(forceDirection * pushForce,transform.position,ForceMode.Impulse);
            }
        }
    }
}
