namespace StoreModel
{

    /// <summary>
    /// Customer Class with Private Fields,Default Constructor
    /// </summary>
    /// Instead of throwing exceptions, a suggestion is made to fix.
    /// Input Validation on UI side should fix the issues instead of a THROW
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
                    Console.WriteLine("First Name must be entered.");
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
                    Console.WriteLine("Last Name must be entered.");
                }

            }
        }

        private string _DateofBirth;
        public string CDateofBirth
        {
            get { return _DateofBirth; }

            set 
            { 
                if (value != "" & value.Length >= 8)
                {
                    _DateofBirth = value; 
            
                }
                else
                {
                    Console.WriteLine("Date of Birth must be 8 Numeric Characters. MMDDYYYY");
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
                    Console.WriteLine("Address must be entered.");
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
                    Console.WriteLine("City must be entered.");
                }

            }
        }
   
        private string _CustomerState;
        public string CustomerState
        {
            get { return _CustomerState; }

            set 
            {
                if (value != "")
                {
                    _CustomerState = value;
                }
                else
                {
                    Console.WriteLine("Must Be 2 Letters");
                }

            }
        }
        private string _CustomerZipcode;
        public string CustomerZipcode
        {
            get { return _CustomerZipcode; }

            set 
            {
                if (value != "")
                {
                    _CustomerZipcode = value;
                }
                else
                {
                    Console.WriteLine("Cant be Null.");
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
                    Console.WriteLine("City must be entered.");
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
                    Console.WriteLine("Email must have a input.");
                }

            }
        }
        private string _Password;
        public string CPassword
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
                    Console.WriteLine("Password must have an input.");
                }
 
            }
        }

        //Default Class Constructor
        public Customers()
        {
            CFirstName = "STEPHEN";
            CLastName = "STRANGE";
            CDateofBirth = "11181930";
            CustomerAddress = "117A BlEECKER STREET";
            CustomerState = "NY";
            CustomerCity = "NEW YORK CITY";
            CustomerZipcode = "10011";
            CustCountry = "USA";
            CustomerEmail = "STEPHEN.STRANGE@AOL.COM";
            CPassword = "mordoisajerk";
        }

        public override string ToString()
        {
            return $"Product Id: {CustomerID}\nFirst Name: {CFirstName}\nLast name: {CLastName}\nDate of Birth {CDateofBirth}" +
            $"\nAddress: {CustomerAddress}\nCustomer State: {CustomerState}\nCustomer City: {CustomerCity}" +
            $"\nCustomer Country: {CustCountry}\nEmail: {CustomerEmail}";
        }
    }
}