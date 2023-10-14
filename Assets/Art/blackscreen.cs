using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blackscreen : MonoBehaviour
{
    public GameObject targetObject;
    public float interval = 2f;
    private bool isActive = true;

    void Start()
    {
        // Belirli aral�klarla InvokeRepeating fonksiyonunu kullanarak fonksiyonu �a��rabiliriz.
        InvokeRepeating("ToggleObjectState", 0f, interval);
    }

    void ToggleObjectState()
    {
        // isActive de�i�kenine g�re GameObject'in aktiflik durumunu de�i�tiriyoruz.
        targetObject.SetActive(isActive);
        isActive = !isActive; // isActive'i tersine �eviriyoruz (true ise false, false ise true yapar).
    }


}
