//using VRClassroom;

namespace VRClassroom
{
    public class Participant
    {
        private string firstName;
        private string lastName;
        private string email;
        private string status;
        private string password;

        public Participant(string firstName = "default", string lastName = "default", string email = "default", string password = "default", string status = "default")
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.password = password;
            this.status = status;
        }

        public bool validateNewAccount()
        {
            DatabaseManager credentials = new DatabaseManager();

            return credentials.CheckNewCredentials(this);
        }

        public void createUserAccount()
        {
            DatabaseManager db = new DatabaseManager();
            db.AddParticipantToDatabase(this);
        }

        #region getters
        public string GetFirstName()
        {
            return firstName;
        }

        public string GetLastName()
        {
            return lastName;
        }

        public string GetEmail()
        {
            return email;
        }

        public string GetStatus()
        {
            return status;
        }

        public string GetPassword()
        {
            return password;
        }
        #endregion

        #region setters
        public void SetFirstName(string value)
        {
            firstName = value;
        }

        public void SetLastName(string value)
        {
            lastName = value;
        }

        public void SetEmail(string value)
        {
            email = value;
        }

        public void SetStatus(string value)
        {
            status = value;
        }

        public void SetPassword(string value)
        {
            password = value;
        }
        #endregion
    }
}
