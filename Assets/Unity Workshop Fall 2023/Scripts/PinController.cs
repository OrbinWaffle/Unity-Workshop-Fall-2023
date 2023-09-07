using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinController : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject pin;
    public GameObject particleEffect;
    void Start()
    {
        pin = transform.GetChild(0).gameObject;
        StartCoroutine(PinCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PinCoroutine()
    {
        yield return new WaitForSeconds(Random.Range(0,1));
        pin.SetActive(false);
        Instantiate(particleEffect, transform.position, transform.rotation);
        yield return new WaitForSeconds(Random.Range(5,15));
        pin.SetActive(true);
        Instantiate(particleEffect, transform.position, transform.rotation);
    }
}
