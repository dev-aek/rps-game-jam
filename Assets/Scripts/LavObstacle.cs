using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavObstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Buzo")
        {
            Destroy(collision.gameObject);
            AudioManager.Instance.PlaySFX("Glass");
        }
    }
}
