﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMovement : MonoBehaviour
{
    public float speed;
   
    
    void Update()
    {
        transform.position += -Vector3.forward * Time.deltaTime * speed;
    }
}
