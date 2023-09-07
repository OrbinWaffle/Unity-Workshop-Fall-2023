using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipManager : MonoBehaviour
{
    [SerializeField] GameObject[] listOne;
    [SerializeField] GameObject[] listTwo;
    [SerializeField] Material matOne;
    [SerializeField] Material matTwo;
    [SerializeField] Material matOff;
    bool status;
    void Start()
    {
        Flip();
    }
    public void Flip()
    {
        foreach(GameObject obj in listOne)
        {
            MeshRenderer MR = obj.GetComponent<MeshRenderer>();
            MR.material = status ? matOff : matOne;
            obj.GetComponent<Collider>().enabled = !status;
        }
        foreach(GameObject obj in listTwo)
        {
            MeshRenderer MR = obj.GetComponent<MeshRenderer>();
            MR.material = status ? matTwo : matOff;
            obj.GetComponent<Collider>().enabled = status;
        }
        status = !status;
    }
}
