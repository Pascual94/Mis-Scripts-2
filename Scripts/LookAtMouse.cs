using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Camera mainCamera;
    void Start()
    {
        if(target == null)
        {
            target = transform;
        }

        if(mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    void Update()
    {
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0;

        Vector3 lookAtDirection = mouseWorldPosition - target.position;
        target.right = lookAtDirection;
    }
}
