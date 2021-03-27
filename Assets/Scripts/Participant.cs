using VRClassroom;

namespace VRClassroom
{
    public class Participant
    {
        private string firstName;
        private string lastName;
        private string email;
        private string status;
        private string password;

        public Participant(string firstName, string lastName, string email, string password, string status)
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
    }
}
