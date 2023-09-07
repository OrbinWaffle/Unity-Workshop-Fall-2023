using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class AgentController : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        // update animations
        anim.SetFloat("moveSpeed", agent.velocity.magnitude/5);
        anim.SetFloat("animSpeedMult", 1 + agent.velocity.magnitude/50);
        anim.SetBool("IsGrounded", !agent.isOnOffMeshLink);
        anim.SetFloat("VerticalVelocity", 1);
    }
    public void NavigateTo(Vector3 position)
    {
        agent.SetDestination(position);
    }
    public void NavigateTo(string position)
    {
        // read three space-separated values in a string, construct Vector3, and set navigation point
        string[] coordinatesString = position.Split(" ");
        float[] coordinates = new float[coordinatesString.Length];
        for(int i = 0; i < coordinatesString.Length; ++i)
        {
            coordinates[i] = float.Parse(coordinatesString[i]);
        }
        Vector3 posVector = new Vector3(coordinates[0], coordinates[1], coordinates[2]);
        agent.SetDestination(posVector);
    }
}
