using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletedCannon : MonoBehaviour
{
    public float force = 1;
    public GameObject cannonball;
    void Start()
    {
        FireCannon();
    }

    public void FireCannon()
    {
        GameObject obj = Instantiate(cannonball, transform.position, transform.rotation);
        Rigidbody RB = obj.GetComponent<Rigidbody>();
        RB.AddForce(Vector3.right * force * RB.mass);
    }
}
