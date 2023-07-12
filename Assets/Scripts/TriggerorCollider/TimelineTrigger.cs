using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;

public class TimelineTrigger : MonoBehaviour
{
    public GameObject timelineClip;
    public GameObject mainCharacter;
    public GameObject cutSceneCam;

    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        cutSceneCam.SetActive(true);
        timelineClip.SetActive(true);
        mainCharacter.SetActive(false);
        StartCoroutine(FinishCut());
    }

    IEnumerator FinishCut()
    {
        yield return new WaitForSeconds(10);
        mainCharacter.SetActive(true);
        cutSceneCam.SetActive(false);
        timelineClip.SetActive(false);
    }
}
