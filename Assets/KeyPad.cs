using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPad : MonoBehaviour
{
    private string userInput = "";
    
    private void Start() {
        userInput = "";
    }

    public void ButtonClicked(string input)
    {
        userInput += input;
        Debug.Log(userInput);
    }

    public void hide()
    {
        // gameObject
    }
}