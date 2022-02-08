namespace StoreModel
{

    /// <summary>
    /// Customer Class with Private Fields,Default Constructor
    /// </summary>
    public class Customers
    {
    
        public int CustomerID { get; set; }
        private string _CFirstName;
        public string CFirstName
        {
            get { return _CFirstName; }

            set 
            {
                if (value != "")
                {
                    _CFirstName = value;
                }
                else
                {
                    throw new NullReferenceException("First Name must be entered.");
                }

            }
        }

        private string _CLastName;
        public string CLastName
        {
            get { return _CLastName; }

            set 
            {
                if (value != "")
                {
                    _CLastName = value;
                }
                else
                {
                    throw new NullReferenceException("Last Name must be entered.");
                }

            }
        }

        private string _DateofBirth;
        public string CDateofBirth
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
                if (value.Length == 2)
                {
                    _CustomerState = value;
                }
                else
                {
                    throw new NullReferenceException("Not Enough Digits");
                }
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
            get { return _CustCountry; }

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
                if (string.IsNullOrEmpty(value))
                {
                    throw new NullReferenceException("Email must have a input.");
                }
                else
                {
                    _CustomerEmail = value;
                }

            }
        }
        private string _Password;
        public string CPassword
        {
            get { return _Password; }

            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new NullReferenceException("Password must have an input.");

                }
                else
                {
                    _Password = value;
                }

            }
        }

        //Default Class Constructor
        public Customers()
        {
            CustomerID = 0;
            CFirstName = "John";
            CLastName = "Doe";
            CDateofBirth = "010180";
            CustomerAddress = "111 Street St";
            CustomerState = "GA";
            CustomerCity = "Macon";
            CustomerZipcode = "55555";
            CustCountry = "USA";
            CustomerEmail = "john@aol.com";
            CPassword = "john@aol.com";
        }

        public override string ToString()
        {
            return $"Product Id: {CustomerID}\nFirst Name: {CFirstName}\nLast name: {CLastName}\nDate of Birth {CDateofBirth}" +
            $"\nAddress: {CustomerAddress}\nCustomer State: {CustomerState}\nCustomer City: {CustomerCity}" +
            $"\nCustomer Country: {CustCountry}\nEmail: {CustomerEmail}";
        }
    }
}