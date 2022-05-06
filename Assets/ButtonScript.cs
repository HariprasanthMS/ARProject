using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System;

public class ButtonScript : MonoBehaviour
{
    private IDictionary<int, string> dict = new Dictionary<int, string>();
    public int keypadNumber = 1;
    public GameObject self;
    public GameObject parent;
    public GameObject popup;
    public UnityEvent KeypadClicked;

    private void OnMouseDown() {
        // KeypadClicked.Invoke();
        // popup = parent.transform.GetChild(1).gameObject;
        string keys_to_display = dict[keypadNumber];
        int iter = 1;
        foreach(char c in keys_to_display)
        {
            TMP_Text text = (TMP_Text)popup.transform.Find("Button"+iter).GetComponent<TMP_Text>();
            Debug.Log(text);
            iter++;
        }
        popup.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        dict.Add(new KeyValuePair<int, string>(1, "."));
        dict.Add(new KeyValuePair<int, string>(2, "ABC"));
        dict.Add(new KeyValuePair<int, string>(3, "DEF"));
        dict.Add(new KeyValuePair<int, string>(4, "GHI"));
        dict.Add(new KeyValuePair<int, string>(5, "JKL"));
        dict.Add(new KeyValuePair<int, string>(6, "MNO"));
        dict.Add(new KeyValuePair<int, string>(7, "PQRS"));
        dict.Add(new KeyValuePair<int, string>(8, "TUV"));
        dict.Add(new KeyValuePair<int, string>(9, "WXYZ"));
        dict.Add(new KeyValuePair<int, string>(0, " "));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}