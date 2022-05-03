using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterButtonScript : MonoBehaviour
{
    public GameObject parent;
    public UnityEvent KeypadClicked;

    private void OnMouseDown() {
        KeypadClicked.Invoke();
        parent.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
