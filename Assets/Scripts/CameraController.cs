using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Vector3 offset = Vector3.zero;
    [SerializeField] float smoothTime = 0f;
    [SerializeField] float distance;
    [SerializeField] Transform targetObj;

    public Vector2 lookVector
    {
        get;
        set;
    }

    Vector3 root;

    Vector3 velocity;
    void Update()
    {
        root = Vector3.SmoothDamp(root, targetObj.position + offset, ref velocity, smoothTime);
        transform.position = root + -transform.forward * distance;
    }
}
