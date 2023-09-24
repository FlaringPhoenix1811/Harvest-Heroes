using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;

    Vector3 camOffSet;
    void Start()
    {
        camOffSet = transform.position - target.position;   
    }

    private void FixedUpdate()
    {
        transform.position = target.position + camOffSet;
    }
}
