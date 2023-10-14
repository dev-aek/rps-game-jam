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
        // Belirli aralýklarla InvokeRepeating fonksiyonunu kullanarak fonksiyonu çaðýrabiliriz.
        InvokeRepeating("ToggleObjectState", 0f, interval);
    }

    void ToggleObjectState()
    {
        // isActive deðiþkenine göre GameObject'in aktiflik durumunu deðiþtiriyoruz.
        targetObject.SetActive(isActive);
        isActive = !isActive; // isActive'i tersine çeviriyoruz (true ise false, false ise true yapar).
    }


}
