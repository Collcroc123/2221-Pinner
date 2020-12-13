using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplayer : MonoBehaviour
{
    public GameObject textPanel;
    public Text textBox;
    public string text;

    private void Start()
    {
        textPanel.SetActive(false);
        textBox.text = text;
    }

    private void OnTriggerEnter(Collider other)
    {
        textPanel.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        textPanel.SetActive(false);
    }
}
