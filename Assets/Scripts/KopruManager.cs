using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class KopruManager : MonoBehaviour
{
    public Transform refPoint;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            transform.DOMove(refPoint.position,1f);
            gameObject.GetComponent<Collider>().enabled = false;
        }
    }
}
