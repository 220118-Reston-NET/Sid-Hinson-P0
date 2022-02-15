
namespace StoreModel
{

    public class StoreFronts
    {
 
        private int _storeID;
        public int StoreID
        {
            get
            {
                  return _storeID;
            }
            set
            {
                 _storeID = value;
            }
        }


        private string _storeZipCode; 
        public string StoreZipCode
        {
                get
                {
                    return _storeZipCode;
                }
                set
                {
                    int length = value.Length;

                    if (string.IsNullOrEmpty(value))
                    {
                         throw new NullReferenceException("Zip code must have an input");
                    }
                    else if(value.Length < 5)
                    {
                        throw new Exception("Zipcode is not long enough");
                    }
                    else
                    {
                        _storeZipCode = value;
                    }
                    
                }
        } 


        private string _storeState;
        public string StoreState
        {
                get
                {
                    return _storeState;
                }
                set
                {
                    int length = value.Length;
                    if (string.IsNullOrEmpty(value))
                    {
                         throw new NullReferenceException("State Abbreviation must have an input");
                    }
                    else if(value.Length < 2 || value.Length > 2)
                    {
                        throw new Exception("State abbreviation is two letters");
                    }
                    else
                    {
                        _storeState = value;
                    }
                    
                }
        }


        private string _storeAddress; 
        public string StoreAddress
        {
                get
                {
                    return _storeAddress;
                }
                set
                {
                    if (string.IsNullOrEmpty(value))
                    {
                         throw new NullReferenceException("Store Address must have an input");
                    }
                    else
                    {
                        _storeAddress = value;
                    }
                    
                }
        }


        private string _storeCity; 
        public string StoreCity
        {
                get
                {
                    return _storeCity;
                }
                set
                {
                    if (string.IsNullOrEmpty(value))
                    {
                         throw new NullReferenceException("Store City must have a input");
                    }

                    _storeCity = value;
                }
        }
        
        public int OrderID { get; set; }
        public string OrderDate { get; set; }
        public double OrderTotal { get; set; }
        public string OrderStatus { get; set; }
        public int CustID { get; set; }
        public string CLastName { get; set; }


        //Default Class Constructor
        public StoreFronts()
        {
            StoreAddress = "742 CHERRY STREET";
            StoreZipCode = "30210";
            StoreState = "GA";
            StoreCity = "MACON";
        }

        public override string ToString()
        {
            return $"Store Number: {StoreID}\nStore Address: {StoreAddress}\nStore ZipCode: {StoreZipCode}" +
            $"\nStore City: {StoreCity}\nStore State: {StoreState}";
        }

    }

}