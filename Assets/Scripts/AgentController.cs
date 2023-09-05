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
        anim.SetFloat("moveSpeed", agent.velocity.magnitude/5);
    }
    public void NavigateTo(Vector3 position)
    {
        agent.SetDestination(position);
    }
    public void NavigateTo(string position)
    {
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
