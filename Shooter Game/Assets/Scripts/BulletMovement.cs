using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    public float speed;
    void Start()
    {
      
    }

    void Update()
    {
        transform.position += Vector3.forward * Time.deltaTime * speed;
    }
}
