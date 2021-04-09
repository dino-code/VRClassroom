using UnityEngine.Networking;
using UnityEngine;

using RestSharp;

namespace VRClassroom
{
    public class DatabaseManager
    {

        static DatabaseManager()
        {

        }

        public bool AddParticipantToDatabase(Participant participant)
        {
            // check first to see if the participant exists in the database (do this in a private method)
            if (!CheckForExistingEmail(participant))
            {
                var client = new RestClient("http://vrclass-env.eba-24xji93n.us-east-1.elasticbeanstalk.com");

                var request = new RestRequest("/addNewUser", Method.POST, DataFormat.Json);

                request.AddJsonBody(new
                {
                    firstName = participant.GetFirstName(),
                    lastName = participant.GetLastName(),
                    email = participant.GetEmail(),
                    password = participant.GetPassword(),
                    status = participant.GetStatus()
                });

                IRestResponse response = client.Execute(request);
                var content = response.Content;

                Debug.Log(content);

                if (content == "Complete")
                    return true;
            }

            return false;
        }

        public bool CheckForExistingEmail(Participant participant)
        {
            var client = new RestClient("http://vrclass-env.eba-24xji93n.us-east-1.elasticbeanstalk.com");

            var request = new RestRequest("/checkForExistingEmail", Method.POST, DataFormat.Json);

            //request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new
            {
                email = participant.GetEmail()
            });

            IRestResponse response = client.Execute(request);
            var content = response.Content;

            Debug.Log(content);

            if (content == "email exists")
            {
                return true;
            }

            return false;
        }

        public bool CheckLoginCredentials(Participant participant)
        {
            UnityWebRequest request = new UnityWebRequest();

            

            //form = ParticipantToForm(participant, form);
            /*
            For any HTTP transaction, the normal code flow is:

            Create a Web Request object
            Configure the Web Request object
            Set custom headers
            Set HTTP verb(such as GET, POST, HEAD - custom verbs are permitted on all platforms except for Android)
                            Set URL
                            (Optional) Create an Upload Handler and attach it to the Web Request
                            Provide data to be uploaded
            Provide HTTP form to be uploaded
            (Optional) Create a Download Handler and attach it to the Web Request
            Send the Web Request
            If inside a coroutine, you may Yield the result of the Send() call to wait for the request to complete
            (Optional) Read received data from the Download Handler
            (Optional) Read error information, HTTP status code and response headers from the UnityWebRequest object
            *.

            /*
            WWWForm form = new WWWForm();
            form.AddField("firstName", participant.GetFirstName());
            form.AddField("lastName", participant.GetLastName());
            form.AddField("email", participant.GetEmail());
            form.AddField("password", participant.GetPassword());
            form.AddField("status", participant.GetStatus());

            UnityWebRequest www = UnityWebRequest.Post("http://127.0.0.1:5000/checkNewEntry", form);
            www.SendWebRequest();

            // get response

            */

            return true;
        }

        public WWWForm ParticipantToForm(Participant participant, WWWForm form)
        {
            form.AddField("firstName", participant.GetFirstName());
            form.AddField("lastName", participant.GetLastName());
            form.AddField("email", participant.GetEmail());
            form.AddField("password", participant.GetPassword());
            form.AddField("status", participant.GetStatus());

            return form;
        }

    } 
}
