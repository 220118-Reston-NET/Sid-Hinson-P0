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
        // Phone Number of Customer
        private string _phonenumber;
        public string PhoneNumber
        {
            get { return _phonenumber; }

            set 
            {
                if (value != "")
                {
                    _phonenumber = value;
                }
                else
                {
                    throw new NullReferenceException("Phone Number must be entered.");
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
        //Orders Will contain Order Number
        private List<Orders> _customerorder;

        public List<Orders> CustomerOrder
        {
            get{ return _customerorder; }

            set 
            {
                if(value.Count <= 10)
                {
                _customerorder = value;
                }
                else
                {
                    throw new Exception("Customer List Must have 10 fields or less.");
                }
            }
        }

        //Randomized Test Stat that will determine Monthly Prize Winner from Customer DB
        public int OfferLottery { get; set; }

        //Default Class Constructor
        public Customer()
        {
            FirstName = "Tyler";
            LastName = "Durden";
            Address = "420 Paper St Wilmington DE 19886";
            PhoneNumber = "5555555555";
            Email = "tylerdurden@protonmail.com";
            OfferLottery = 0;
            _customerorder = new List<Orders>();
        }
    }
}