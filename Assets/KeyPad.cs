using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class KeyPad : MonoBehaviour
{
    private string userInput = "";
    private TMP_Text inputBuffer;

    private void Start() {
        userInput = "";
        inputBuffer = (TMP_Text)GameObject.Find("InputBuffer").GetComponent<TMP_Text>();
        inputBuffer.text = "";
    }

    public void ButtonClicked(string input)
    {
        userInput += input;
        inputBuffer.text = userInput;
        Debug.Log("Keypad input: "+userInput);
    }

    public void hide()
    {
        // gameObject
    }
}