using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthManager : MonoBehaviour
{
    int buzoNumber=0;
    public GameObject dstryObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Buzo")
        {
            Destroy(other);
            buzoNumber += 1;
            if (buzoNumber==2)
            {
                Destroy(dstryObject);
            }
        }
    }

}
