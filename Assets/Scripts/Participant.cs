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

        public bool ValidateLoginCredentials()
        {
            // This method calls upon the DatabaseManager class to validate whether valid credentials are present in the database.
            // If credentials are present, a value of true is returned.

            if (InputsValid())
            {
                DatabaseManager credentials = new DatabaseManager();

                return credentials.ValidateLoginCredentials(this);
            }

            return false;
            
        }

        private bool InputsValid()
        {
            // This method checks that email, password, firstname, and lastname all have valid entries. It is meant to be called before using the 
            // DatabaseManager to connect to the databse (to prevent null entries from being added).
            if (this.GetFirstName().Length > 0 && this.GetLastName().Length > 0 && (this.GetEmail().Length > 0 && this.GetEmail().Contains("@")) && this.GetPassword().Length > 0) {
                return true;
            }

            return false;
        }

        public bool CreateUserAccount()
        {
            // This method sends a request to create a new user account
            DatabaseManager db = new DatabaseManager();
            db.AddParticipantToDatabase(this);
            /*
            if (this.InputsValid())
            {
                

                // the database manager shoud be used to check if there is a participant in the database.
                // This method will then return true if the participant was added and false if they weren't
                // This can be a private method in AddParticipantToDatabase. AddParticipantToDatabase will
                // Then return true or false depending on whether the validation occurred successfully
                // and determined that there was not an existing entry.
                if (db.AddParticipantToDatabase(this))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            */
            

            return true;
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
