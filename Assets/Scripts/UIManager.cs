using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;

using VRClassroom;

public class UIManager : MonoBehaviour
{
    private GameObject startScreen;
    private GameObject createAccountScreen;
    private Button createAccountSubmitButton;

    /*
    #region FormData_class
    public struct FormData
    {
        public string firstName;
        public string lastName;
        public string emailAddress;
        public string status;
        public string password;
        
    }
    #endregion
    */
    // Start is called before the first frame update
    void Start()
    {
        /*
        // Screens
        startScreen = GameObject.Find("welcome_screen");
        createAccountScreen = GameObject.Find("create_acc_screen");

        // Buttons
        createAccountSubmitButton = GameObject.Find("Submit_Button").gameObject.GetComponent<Button>();

        // Show/Hide screens
        startScreen.SetActive(true);
        createAccountScreen.SetActive(false);
        */

        Debug.Log("LOOK HERE AJD;LKFJASD;LFKJDSAGKJAOIGJAOWGJOSDGJAOGPJ");

        Participant participant = new Participant("Dino", "Becaj", "dbecaj@fordham.edu", "lalala123", "Student");

        Debug.Log("Status" + participant.validateNewAccount());
        /*
        WWWForm form = new WWWForm();
        form.AddField("firstName", "Dino-NewTest");
        form.AddField("lastName", "Dino-NewTest");
        form.AddField("email", "Dino-NewTest");
        form.AddField("password", "Dino-NewTest");
        form.AddField("status", "Dino-NewTest");

        UnityWebRequest www = UnityWebRequest.Post("http://127.0.0.1:5000/addEntry", form);
        www.SendWebRequest();
        Debug.Log("Success");
        */



    }

    public void ShowCreateAccountScreen()
    {
        startScreen.SetActive(false);
        createAccountScreen.SetActive(true);
    }

    public void OnSubmitClick()
    {
        Debug.Log("Submit Clicked");

        // Extract fields from the UI
        /*
        FormData data = new FormData();
        data = GetDataFromUI();
        */

        // Need to call a function here that verifies whether the input is valid.
        // Check against database to see whether these credentials have been used before. If they have, show an error.
        // Check to see that all the fields are filled. If they are not, show an error.
        /*
        Debug.Log(data.firstName);
        Debug.Log(data.lastName);
        Debug.Log(data.emailAddress);
        Debug.Log(data.password);
        Debug.Log(data.status);
        */
        /*
        string connString = "Host=database-2.cxulhfpnprky.us-east-1.rds.amazonaws.com:5342;Username=postgres;Password=Finance123!;Database=database-2";
        using var conn = new NpgsqlConnection(connString);
        */
        /*
        string url = "http://127.0.01:5000/addEntry";
        string method = "POST";

        WWWForm form = new WWWForm();
        form.AddField("firstName", data.firstName);
        form.AddField("lastName", data.lastName);
        form.AddField("email", data.emailAddress);
        form.AddField("password", data.password);
        form.AddField("status", data.status);

        UnityWebRequest www = UnityWebRequest.Post(url, form);
        www.SendWebRequest();
        Debug.Log("Success");
        */

        //string jsonString = JsonSerializer.Serialize(data);

        //Debug.Log(jsonString);

        //UnityWebRequest req = new UnityWebRequest(url, method, );
    }
    /*
    private FormData GetDataFromUI()
    {
        FormData data = new FormData();

        data.firstName = GameObject.Find("FirstName").GetComponent<TMP_InputField>().text;
        data.lastName = GameObject.Find("LastName").GetComponent<TMP_InputField>().text;
        data.emailAddress = GameObject.Find("Email").GetComponent<TMP_InputField>().text;
        data.status = GameObject.Find("Status").GetComponent<TMP_Dropdown>().itemText.text;
        data.password = GameObject.Find("Password").GetComponent<TMP_InputField>().text;

        return data;
    }
    */

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
