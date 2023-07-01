using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigDoor2 : MonoBehaviour
{
    [SerializeField] private Animator myDoor;

    [SerializeField] private bool openTrigger = false;
    [SerializeField] private bool closeTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (openTrigger)
            {
                myDoor.Play("DoorOpen",0,0.0f);
                gameObject.SetActive(false);
            }          
            else if (closeTrigger)
            {
                myDoor.Play("DoorOpen",0,0.0f);
                gameObject.SetActive(false);
            }
        }
    }
}
