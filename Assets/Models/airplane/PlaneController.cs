using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{

    [SerializeField] Transform pervane;

    public float d�nmeH�z� = 200f;
    private float donmeH�z�;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, donmeH�z� * Time.deltaTime);
    }
}
