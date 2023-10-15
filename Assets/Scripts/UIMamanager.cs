using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIMamanager : MonoBehaviour
{
    public static UIMamanager Instance;

    public string[] dialogs;
    public GameObject dialogPanel;
    public TextMeshProUGUI dialogText;


    void Awake()
    {
        if (Instance == null) 
        {
            DontDestroyOnLoad(gameObject); 
            Instance = this;
        }
        else if (Instance != this) 
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            dialogPanel.active = false;

        }
    }

    public void SetDialog(int i)
    {
        dialogText.text = dialogs[i];
        dialogPanel.active = true;
    }
}
