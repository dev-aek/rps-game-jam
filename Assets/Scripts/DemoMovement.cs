using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoMovement : MonoBehaviour
{
 public float moveSpeed = 5.0f;

    private void Update()
    {
        // Yatay (horizontal) ve dikey (vertical) giri�i al
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Hareket vekt�r�n� olu�tur
        Vector3 moveDirection = new Vector3(horizontalInput, 0.0f, verticalInput);

        // Hareket vekt�r�n� normalle�tir (uzunlu�unu 1'e getir)
        moveDirection.Normalize();

        // Karakterin d�nya uzay�nda hareket etmesini sa�la
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
    void Start()
    {
        
    }

}
