using UnityEngine;

using RestSharp;        // Used for requests

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

        public bool ValidateLoginCredentials(Participant participant)
        {
            var client = new RestClient("http://vrclass-env.eba-24xji93n.us-east-1.elasticbeanstalk.com");

            var request = new RestRequest("/validateLoginCredentials", Method.POST, DataFormat.Json);

            //request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new
            {
                email = participant.GetEmail(),
                password = participant.GetPassword()
            });

            IRestResponse response = client.Execute(request);
            var content = response.Content;

            Debug.Log(content);

            if (content == "account exists")
            {
                return true;
            }

            return false;
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
