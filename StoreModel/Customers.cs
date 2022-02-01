namespace StoreModel
{

    /// <summary>
    /// Customer Class with Private Fields,Default Constructor
    /// </summary>
    public class Customers
    {
    
        public string CustomerID;
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }

            set 
            {
                if (value != "")
                {
                    _firstName = value;
                }
                else
                {
                    throw new NullReferenceException("First Name must be entered.");
                }

            }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }

            set 
            {
                if (value != "")
                {
                    _lastName = value;
                }
                else
                {
                    throw new NullReferenceException("Last Name must be entered.");
                }

            }
        }

        private string _dateofBirth;
        public string DateofBirth
        {
            get { return _dateofBirth; }

            set 
            { 
                if (value != "")
                {
                    _dateofBirth = value; 
            
                }
                else
                {
                    throw new NullReferenceException("Last Name must be entered.");
                } 
                
            }
        }
        private string _customerAddress;
        public string CustomerAddress
        {
            get { return _customerAddress; }

            set 
            {
                if (value != "")
                {
                    _customerAddress = value;
                }
                else
                {
                    throw new NullReferenceException("Address must be entered.");
                }

            }
        }
        private string _customerCity;
        public string CustomerCity
        {
            get { return _customerCity; }

            set 
            {
                if (value != "")
                {
                    _customerCity = value;
                }
                else
                {
                    throw new NullReferenceException("City must be entered.");
                }

            }
        }
   
        private string _customerState;
        public string CustomerState
        {
            get { return _customerState; }

            set 
            {
               _customerState = value;
            }
        }
        private string _customerZipcode;
        public string CustomerZipcode
        {
            get { return _customerZipcode; }

            set 
            {
                if (value.Length >= 5)
                {
                    _customerZipcode = value;
                }
                else
                {
                    throw new NullReferenceException("Not Enough Digits");
                }

            }
        }

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
        private string _password;
        public string Password
        {
            get { return _password; }

            set 
            {
                if (value != "")
                {
                    _password = value;
                }
                else
                {
                    throw new NullReferenceException("password must be entered.");
                }

            }
        }

        private List<Orders> _customerOrder;

        public List<Orders> CustomerOrder
        {
            get{ return _customerOrder; }

            set 
            {
                if(value.Count <= 10)
                {
                _customerOrder = value;
                }
                else
                {
                    throw new Exception("Customer List Must have 10 fields or less.");
                }
            }
        }


        //Default Class Constructor
        public Customers()
        {
            CustomerID = "";
            FirstName = "Tyler";
            LastName = "Durden";
            DateofBirth = "102180";
            CustomerAddress = "420 Paper St Wilmington DE 19886";
            CustomerState = "CA";
            CustomerCity = "Lancaster";
            CustomerZipcode = "55555";
            Email = "tylerdurden@protonmail.com";
            CustomerOrder = new List<Orders>();
            Password = "robertpaulson";
        }

        public override string ToString()
        {
            return $"First Name: {FirstName}\nLast name: {LastName}\nDate of Birth {DateofBirth}" +
            $"\nAddress: {CustomerAddress}\nEmail: {Email}";
        }
    }
}