using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        root = Vector3.SmoothDamp(root, targetObj.position, ref velocity, smoothTime);
        transform.position = root + -transform.forward * distance;
    }
}
