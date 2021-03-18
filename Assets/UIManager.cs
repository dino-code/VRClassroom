using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameObject startScreen;
    private GameObject createAccountScreen;
    private Button createAccountSubmitButton;
    
    // Start is called before the first frame update
    void Start()
    {
        // Screens
        startScreen = GameObject.Find("welcome_screen");
        createAccountScreen = GameObject.Find("create_acc_screen");

        // Buttons
        createAccountSubmitButton = GameObject.Find("Submit_Button").gameObject.GetComponent<Button>();

        // Show/Hide screens
        startScreen.SetActive(true);
        createAccountScreen.SetActive(false);

    }

    public void ShowCreateAccountScreen()
    {
        startScreen.SetActive(false);
        createAccountScreen.SetActive(true);
    }

    public void OnSubmitClick()
    {
        Debug.Log("Submit Clicked");
        // Gather all the data
        string tag = "formData";
        Transform parent = createAccountScreen.GetComponent<Transform>();
        List<GameObject> children = FindAllChildrenWithTag(parent, tag);

         

    }

    private List<GameObject> FindAllChildrenWithTag(Transform parent, string tag)
    {
        List<GameObject> children = new List<GameObject>();

        foreach (Transform child in parent)
        {
            if (child.CompareTag(tag))
            {
                children.Add(child.gameObject);
            }
        }

        return children;
    }
}
