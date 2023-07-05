using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{

    public GameObject ucak;
    public float speed;
    public float lifespan = 5f;
    private bool hasDestroyed = false;

    void Start()
    {
        Invoke("YokEt", lifespan);
    }

    void YokEt()
    {
        if (!hasDestroyed)
        {
            hasDestroyed = true;
            Destroy(ucak);
        }
    }

    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }
}
