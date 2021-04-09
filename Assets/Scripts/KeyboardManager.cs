using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class KeyboardManager : MonoBehaviour
{
    private TouchScreenKeyboard overlayKeyboard;
    public static string inputText = "";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        overlayKeyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);

        if (overlayKeyboard != null)
        {
            inputText = overlayKeyboard.text;
        }
    }

    public void ShowKeyboard()
    {
        
    }
}
