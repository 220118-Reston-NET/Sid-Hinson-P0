namespace StoreModel
{
    public class Customer
    {
        //First Name of Customer
        private string _firstname;
        public string FirstName
        {
            get { return _firstname; }

            set 
            {
                if (value != "")
                {
                    _firstname = value;
                }
                else
                {
                    throw new NullReferenceException("First Name must be entered.");
                }

            }
        }

        // Last Name of Customer
        private string _lastname;
        public string LastName
        {
            get { return _lastname; }

            set 
            {
                if (value != "")
                {
                    _lastname = value;
                }
                else
                {
                    throw new NullReferenceException("Last Name must be entered.");
                }

            }
        }

        // Birthdate of Customer ( Age restrictions Safeguard)
        //Figure out how to implement a stored date of birth Here (datetime?)


        // Address of Customer
        private string _address;
        public string Address
        {
            get { return _address; }

            set 
            {
                if (value != "")
                {
                    _address = value;
                }
                else
                {
                    throw new NullReferenceException("Address must be entered.");
                }

            }
        }
       
       //Email of Customer
        private string _email;

        public string Email
        {
            get { return _email; }

            set 
            {
                if (value != "")
                {
                    _email = value;
                }
                else
                {
                    throw new NullReferenceException("Email must be entered.");
                }

            }
        }

        //Customer Orders
        //Possibly Figure out how to implement into a Private List
        public List<Orders> _customerorders;

        //Add Constructor Here


    }
}