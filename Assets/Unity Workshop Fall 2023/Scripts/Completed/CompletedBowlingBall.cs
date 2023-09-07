using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletedBowlingBall : MonoBehaviour
{
    public float force = 1f;
    Rigidbody RB;
    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        RB.AddTorque(-Vector3.forward * force * RB.mass);
    }
}
