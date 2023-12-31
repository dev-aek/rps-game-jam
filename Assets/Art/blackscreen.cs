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
        // Belirli aralıklarla InvokeRepeating fonksiyonunu kullanarak fonksiyonu çağırabiliriz.
        InvokeRepeating("ToggleObjectState", 0f, interval);
    }

    void ToggleObjectState()
    {
        // isActive değişkenine göre GameObject'in aktiflik durumunu değiştiriyoruz.
        targetObject.SetActive(isActive);
        isActive = !isActive; // isActive'i tersine çeviriyoruz (true ise false, false ise true yapar).
    }


}
