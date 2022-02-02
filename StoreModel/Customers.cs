namespace StoreModel
{

    /// <summary>
    /// Customer Class with Private Fields,Default Constructor
    /// </summary>
    public class Customers
    {
    
        public int CustomerID { get; set; }
        private string _FirstName;
        public string FirstName
        {
            get { return _FirstName; }

            set 
            {
                if (value != "")
                {
                    _FirstName = value;
                }
                else
                {
                    throw new NullReferenceException("First Name must be entered.");
                }

            }
        }

        private string _FastName;
        public string LastName
        {
            get { return _FastName; }

            set 
            {
                if (value != "")
                {
                    _FastName = value;
                }
                else
                {
                    throw new NullReferenceException("Last Name must be entered.");
                }

            }
        }

        private string _DateofBirth;
        public string DateofBirth
        {
            get { return _DateofBirth; }

            set 
            { 
                if (value != "")
                {
                    _DateofBirth = value; 
            
                }
                else
                {
                    throw new NullReferenceException("Last Name must be entered.");
                } 
                
            }
        }
        private string _CustomerAddress;
        public string CustomerAddress
        {
            get { return _CustomerAddress; }

            set 
            {
                if (value != "")
                {
                    _CustomerAddress = value;
                }
                else
                {
                    throw new NullReferenceException("Address must be entered.");
                }

            }
        }
        private string _CustomerCity;
        public string CustomerCity
        {
            get { return _CustomerCity; }

            set 
            {
                if (value != "")
                {
                    _CustomerCity = value;
                }
                else
                {
                    throw new NullReferenceException("City must be entered.");
                }

            }
        }
   
        private string _CustomerState;
        public string CustomerState
        {
            get { return _CustomerState; }

            set 
            {
               _CustomerState = value;
            }
        }
        private string _CustomerZipcode;
        public string CustomerZipcode
        {
            get { return _CustomerZipcode; }

            set 
            {
                if (value.Length >= 5)
                {
                    _CustomerZipcode = value;
                }
                else
                {
                    throw new NullReferenceException("Not Enough Digits");
                }

            }
        }

        private string _CustCountry;
        public string CustCountry
        {
            get { return CustCountry; }

            set 
            {
                if (value != "")
                {
                    _CustCountry = value;
                }
                else
                {
                    throw new NullReferenceException("City must be entered.");
                }

            }
        }
        private string _CustomerEmail;

        public string CustomerEmail
        {
            get { return _CustomerEmail; }

            set 
            {
                if (value != "")
                {
                    _CustomerEmail = value;
                }
                else
                {
                    throw new NullReferenceException("Email must be entered.");
                }

            }
        }
        private string _Password;
        public string Password
        {
            get { return _Password; }

            set 
            {
                if (value != "")
                {
                    _Password = value;
                }
                else
                {
                    throw new NullReferenceException("password must be entered.");
                }

            }
        }

        private List<Orders> _CustomerOrder;

        public List<Orders> CustomerOrder
        {
            get{ return _CustomerOrder; }

            set 
            {
                if(value.Count <= 10)
                {
                _CustomerOrder = value;
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
            CustomerID = 0;
            FirstName = "John";
            LastName = "Doe";
            DateofBirth = "010180";
            CustomerAddress = "111 Street St";
            CustomerState = "GA";
            CustomerCity = "Macon";
            CustomerZipcode = "55555";
            CustCountry = "USA";
            CustomerEmail = "john@aol.com";
            CustomerOrder = new List<Orders>();
            Password = "john@aol.com";
        }

        public override string ToString()
        {
            return $"Product Id: {CustomerID}\nFirst Name: {FirstName}\nLast name: {LastName}\nDate of Birth {DateofBirth}" +
            $"\nAddress: {CustomerAddress}\nEmail: {CustomerEmail}";
        }
    }
}