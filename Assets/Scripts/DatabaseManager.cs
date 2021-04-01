using VRClassroom;

using UnityEngine.Networking;
using UnityEngine;

namespace VRClassroom
{
    public class DatabaseManager
    {
        public DatabaseManager()
        {
            
        }

        public bool AddParticipantToDatabase(Participant participant)
        {
            WWWForm form = new WWWForm();
            form = ParticipantToForm(participant, form);

            UnityWebRequest www = UnityWebRequest.Post("http://vrclass-env.eba-24xji93n.us-east-1.elasticbeanstalk.com/addEntry", form);
            www.SendWebRequest();

            return true;
        }

        public bool CheckNewCredentials(Participant participant)
        {
            WWWForm form = new WWWForm();
            form = ParticipantToForm(participant, form);
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

