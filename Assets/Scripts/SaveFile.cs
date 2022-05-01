using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveFile : MonoBehaviour
{
    [SerializeField] TMP_InputField inputfield;
    void Start()
    {
        inputfield.text = PlayerPrefs.GetString("name");
    }

    void Update()
    {
        
    }

    public void SaveName()
    {
        PlayerPrefs.SetString("name", inputfield.text);
    }
}
