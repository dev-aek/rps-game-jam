using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoMovement : MonoBehaviour
{
 public float moveSpeed = 5.0f;

    private void Update()
    {
        // Yatay (horizontal) ve dikey (vertical) giriþi al
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Hareket vektörünü oluþtur
        Vector3 moveDirection = new Vector3(horizontalInput, 0.0f, verticalInput);

        // Hareket vektörünü normalleþtir (uzunluðunu 1'e getir)
        moveDirection.Normalize();

        // Karakterin dünya uzayýnda hareket etmesini saðla
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
    void Start()
    {
        
    }

}
