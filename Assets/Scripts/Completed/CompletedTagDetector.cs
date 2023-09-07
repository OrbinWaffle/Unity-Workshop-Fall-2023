using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CompletedTagDetector : MonoBehaviour
{
    [SerializeField] string tagToMatch;
    [SerializeField] UnityEvent OnTagDetected;
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(tagToMatch))
        {
            OnTagDetected.Invoke();
        }
    }
}