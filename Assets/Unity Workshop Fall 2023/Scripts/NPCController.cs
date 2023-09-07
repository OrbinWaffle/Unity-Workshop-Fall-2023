using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AgentController))]
public class NPCController : MonoBehaviour
{
    [SerializeField] UnityEvent OnPlayerTouch;
    [SerializeField] Transform target;
    public bool freeze;


    AgentController AC;
    void Start()
    {
        AC = GetComponent<AgentController>();
    }
    void Update()
    {
        if(!freeze && target)
        {
            AC.NavigateTo(target.position);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Player"))
        {
            OnPlayerTouch.Invoke();
        }
    }
}
