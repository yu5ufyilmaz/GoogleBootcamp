using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{

    [SerializeField] Transform pervane;

    public float dönmeHýzý = 200f;
    private float donmeHýzý;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, donmeHýzý * Time.deltaTime);
    }
}
