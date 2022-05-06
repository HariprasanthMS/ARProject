using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
{
    private string userInput = "";
    public KeyPad keypad;
    // public GameObject self;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonClicked(string number)
    {
        keypad.ButtonClicked(number);
        keypad.hide();
        Debug.Log("keypad hidden: " + number);
        gameObject.SetActive(true);
    }
}
