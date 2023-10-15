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
    public int dialogLevel = 1;
    public GameObject cameraCine;
    public GameObject[] elementUI;

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
        SetDialog(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            dialogPanel.active = false;
            cameraCine.active = false;
        }
    }

    public void SetDialog(int i)
    {
        dialogText.text = dialogs[i];
        dialogPanel.active = true;

        switch (i)
        {
            case 0:
                AudioManager.Instance.PlaySFX("dg");
                break;
            case 1:
                AudioManager.Instance.PlaySFX("dg1");
                break;
            case 2:
                AudioManager.Instance.PlaySFX("dg2");
                break;
            case 3:
                AudioManager.Instance.PlaySFX("dg3");
                break;
            case 4:
                AudioManager.Instance.PlaySFX("dg4");
                break;
            case 5:
                AudioManager.Instance.PlaySFX("dg5");
                break;
            default:
                break;
        }
    }


}
