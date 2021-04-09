using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using TMPro;

using VRClassroom;

public class UIManager : MonoBehaviour
{
    // Screens
    private GameObject startScreen;
    private GameObject createAccountScreen;
    private GameObject loginScreen;

    // Buttons
    private Button createAccountSubmitButton;
    private Button loginSubmitButton;

    // Participant
    private Participant participant;

    // Start is called before the first frame update
    void Start()
    {
        // Screen Assignments
        startScreen = GameObject.Find("welcome_screen");
        createAccountScreen = GameObject.Find("create_acc_screen");
        loginScreen = GameObject.Find("login_screen");

        // Button Assignments
        createAccountSubmitButton = GameObject.Find("Create_Account_Submit_Button").gameObject.GetComponent<Button>();
        loginSubmitButton = GameObject.Find("Login_Submit_Button").gameObject.GetComponent<Button>();

        // Show/Hide screens at start
        startScreen.SetActive(true);
        createAccountScreen.SetActive(false);
        loginScreen.SetActive(false);

        Debug.Log("Success");
    }

    #region ShowScreens
    public void ShowCreateAccountScreen()
    {
        startScreen.SetActive(false);
        createAccountScreen.SetActive(true);
    }

    public void ShowLoginScreen()
    {
        startScreen.SetActive(false);
        createAccountScreen.SetActive(false);
        loginScreen.SetActive(true);
    }
    #endregion

    #region ButtonClicks
    public void OnLoginSubmitClick()
    {
        // First we grab all the login inputs
        string email;
        string password;

        GameObject[] loginInputs = GameObject.FindGameObjectsWithTag("LoginInput");

        for (int i = 0; i < loginInputs.Length; i++)
        {
            if (loginInputs[i].gameObject.name == "Email")
            {
                email = loginInputs[i].GetComponent<TMP_InputField>().text;
            }
            if (loginInputs[i].gameObject.name == "Password")
            {
                password = loginInputs[i].GetComponent<TMP_InputField>().text;
            }
        }
    }

    public void OnCreateAccountSubmitClick()
    {
        Debug.Log("Submit Clicked");

        Participant participant = new Participant();

        GameObject[] createAccountInputs = GameObject.FindGameObjectsWithTag("CreateAccountInput");

        participant = CreateParticipantFromInputFields(participant, createAccountInputs);

        // validate that email and password fields are not empty
        /*
        if (participant.InputsValid())
        {

        }
        else
        {
            Debug.Log("Invalid Inputs");
        }
        */

        participant.CreateUserAccount();

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
    #endregion

    public void ShowErrorMessage()
    {
        // This method should cause an error message to appear based on the kind of error that occurs.
        // Possible error types are (invalid email, password, etc).
    }
    private Participant CreateParticipantFromInputFields(Participant participant, GameObject[] fields)
    {
        for (int i = 0; i < fields.Length; i++)
        {
            Debug.Log(fields[i].gameObject.name);
            if (fields[i].gameObject.name == "FirstName")
            {
                participant.SetFirstName(fields[i].GetComponent<TMP_InputField>().text);
            }
            if (fields[i].gameObject.name == "LastName")
            {
                participant.SetLastName(fields[i].GetComponent<TMP_InputField>().text);
            }
            if (fields[i].gameObject.name == "Email")
            {
                participant.SetEmail(fields[i].GetComponent<TMP_InputField>().text);
            }
            if (fields[i].gameObject.name == "Password")
            {
                participant.SetPassword(fields[i].GetComponent<TMP_InputField>().text);
            }
            if (fields[i].gameObject.name == "Status")
            {
                var sel = fields[i].GetComponent<TMP_Dropdown>();
                int opt = sel.value;
                var opts = sel.options;

                participant.SetStatus(opts[opt].text);
            }
        }

        return participant;
    }
}
