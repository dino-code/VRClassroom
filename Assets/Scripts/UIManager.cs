using UnityEngine;
using UnityEngine.UI;
using TMPro;

using VRClassroom;

public class UIManager : MonoBehaviour
{
    // Screens
    [SerializeField]
    private GameObject startScreen;
    [SerializeField]
    private GameObject createAccountScreen;
    [SerializeField]
    private GameObject loginScreen;

    // Buttons
    [SerializeField]
    private Button createAccountSubmitButton;
    [SerializeField]
    private Button loginSubmitButton;

    // Participant
    private Participant participant;

    // Start is called before the first frame update
    void Start()
    {
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

        participant.CreateUserAccount();

        // Need to call a function here that verifies whether the input is valid.
        // Check against database to see whether these credentials have been used before. If they have, show an error.
        // Check to see that all the fields are filled. If they are not, show an error.        
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
