using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    public Transform target;
    [SerializeField]
    public float smoothSpeed = 0.125f;
    [SerializeField]
    public Vector3 offset;

    void FixedUpdate()
    {
        //Vector2 desiredPosition = target.position + offset;
        //Vector2 smoothedPosition = Vector2.Lerp(transform.position, desiredPosition, smoothSpeed);

        //transform.position = smoothedPosition;

        transform.LookAt(target);
    }
}
