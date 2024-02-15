using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float speed = 20f;

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
