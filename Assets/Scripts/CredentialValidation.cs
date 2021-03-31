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

        public bool CheckNewCredentials(Participant participant)
        {
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


    }
}

