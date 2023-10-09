using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _speed = 5f;
    private void Start()
    {
        
    }
    
    private void Update()
    {
        Vector3 dir = Vector3.up;
        transform.position += dir * _speed * Time.deltaTime;
    }
}
