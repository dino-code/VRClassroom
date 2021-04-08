using UnityEngine.Networking;
using UnityEngine;

using System;
using System.Net.Http;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace VRClassroom
{
    public class DatabaseManager
    {
        private static readonly HttpClient client;
        static DatabaseManager()
        {
            client = new HttpClient();
        }

        static async Task<string> AddEntryTest(Participant participant)
        {
            var values = new Dictionary<string, string>
            {
                { "firstName", participant.GetFirstName() },
                { "lastName", participant.GetLastName() },
                { "email", participant.GetEmail() },
                { "password", participant.GetPassword() },
                { "status", participant.GetStatus() }
            };

            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync("http://vrclass-env.eba-24xji93n.us-east-1.elasticbeanstalk.com/addNewUser", content);

            var responseString = await response.Content.ReadAsStringAsync();

            return responseString;
        }

        static async Task<string> CheckForExistingEmailRequest(Participant participant)
        {
            var values = new Dictionary<string, string>
            {
                { "email", participant.GetEmail() }
            };

            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync("http://vrclass-env.eba-24xji93n.us-east-1.elasticbeanstalk.com/checkForExistingEmail", content);

            var responseString = await response.Content.ReadAsStringAsync();

            return responseString;
        }

        public bool AddParticipantToDatabase(Participant participant)
        {
            // check first to see if the participant exists in the database (do this in a private method)


           

            WWWForm form = new WWWForm();
            form = ParticipantToForm(participant, form);

            UnityWebRequest www = UnityWebRequest.Post("http://vrclass-env.eba-24xji93n.us-east-1.elasticbeanstalk.com/addEntry", form);
            www.SendWebRequest();

            

            // Play around with System.Net


            return true;
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

        
        public bool CheckForExistingEmail(Participant participant)
        {
            
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

