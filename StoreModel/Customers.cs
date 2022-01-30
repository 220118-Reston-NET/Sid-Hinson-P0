namespace StoreModel
{

    /// <summary>
    /// Customer Class with Private Fields,Default Constructor
    /// </summary>
    public class Customers
    {
        //Need a Customer ID *****
        public int customerID;
        private string _firstName;
        public string firstName
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
        public string lastName
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

        private string _dateBirth;
        public string dateBirth
        {
            get { return _dateBirth; }

            set 
            { 
                if (value != "")
                {
                    _dateBirth = value; 
            
                }
                else
                {
                    throw new NullReferenceException("Last Name must be entered.");
                } 
                
            }
        }
        private string _address;
        public string customerAddress
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
   
        private string _phonenumber;
        public string phoneNumber
        {
            get { return _phonenumber; }

            set 
            {
                if (value.Length >= 10)
                {
                    _phonenumber = value;
                }
                else
                {
                    throw new NullReferenceException("Not Enough Phone Digits");
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
        public string password
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

        public List<Orders> customerOrder
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
            customerID = 0;
            firstName = "Tyler";
            lastName = "Durden";
            dateBirth = "102180";
            customerAddress = "420 Paper St Wilmington DE 19886";
            phoneNumber = "5555555555";
            Email = "tylerdurden@protonmail.com";
            customerOrder = new List<Orders>();
            password = "robertpaulson";
        }

        public override string ToString()
        {
            return $"First Name: {firstName}\nLast name: {lastName}\nDate of Birth {dateBirth}" +
            $"\nAddress: {customerAddress}\nPhone Number : {phoneNumber}\nEmail: {Email}";
        }
    }
}