using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TimelineTrigger : MonoBehaviour
{
    public GameObject mainCharacter;
    public GameObject cutSceneCam;

    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        cutSceneCam.SetActive(true);
        mainCharacter.SetActive(false);
        StartCoroutine(FinishCut());
    }

    IEnumerator FinishCut()
    {
        yield return new WaitForSeconds(10);
        mainCharacter.SetActive(true);
        cutSceneCam.SetActive(false);
    }
}
