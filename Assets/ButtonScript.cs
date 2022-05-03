using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonScript : MonoBehaviour
{
    private IDictionary<int, string> dict = new Dictionary<int, string>();
    public int keypadNumber = 1;
    public GameObject self;
    public GameObject parent;
    public UnityEvent KeypadClicked;

    private void OnMouseDown() {
        // KeypadClicked.Invoke();
        self.transform.GetChild(1).gameObject.SetActive(true);
        parent.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        dict.Add(new KeyValuePair<int, string>(1, "ABCD"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}