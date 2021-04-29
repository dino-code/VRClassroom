using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;               // Allows manipulation of Unity UI GameObjects
using TMPro;                        // TextMeshPro package -- manipulation of text in Unity object

using VRClassroom;                  // namespace of the custom functions coded for this project

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
        // Hides other screens and shows Create Account screen
        startScreen.SetActive(false);
        createAccountScreen.SetActive(true);
    }

    public void ShowLoginScreen()
    {
        // Hides other screens and shows login screen
        startScreen.SetActive(false);
        createAccountScreen.SetActive(false);
        loginScreen.SetActive(true);
    }
    #endregion

    #region ButtonClicks
    public void OnLoginSubmitClick()
    {
        // This function is called when the login button is clicked. 
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

        // Check against the database -- if inputs are accepted (validation function returns a bool), then we load the launcher scene.
        // create a participant object and the query the database to validate.


        // 1 is the index of the "Lobby" scene.
        SceneManager.LoadScene(1);
        
    }

    public void OnCreateAccountSubmitClick()
    {
        Debug.Log("Submit Clicked");

        Participant participant = new Participant();

        GameObject[] createAccountInputs = GameObject.FindGameObjectsWithTag("CreateAccountInput");

        participant = CreateParticipantFromInputFields(participant, createAccountInputs);

        participant.CreateUserAccount();

        ///<summary>
        ///Need to call a function here that verifies whether the input is valid.
        // Check against database to see whether these credentials have been used before. If they have, show an error.
        // Check to see that all the fields are filled. If they are not, show an error.
        /// </summary>

        // 1 is the index of the "Lobby" scene.
        SceneManager.LoadScene(1);
    }
    #endregion

    public void ShowErrorMessage()
    {
        // This method should cause an error message to appear based on the kind of error that occurs.
        // Possible error types are (invalid email, password, etc).
    }
    private Participant CreateParticipantFromInputFields(Participant participant, GameObject[] fields)
    {
        // This function grabs the user input data from the Unity form GameObject and fills a participant object with the data.
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
