
namespace StoreModel
{

    public class StoreFronts
    {
 
        public int storeNumber { get; set; }
        public string storeZipCode
        {
            get { return storeZipCode; }
            set 
            {
                if(value.Length >= 5)
                {
                storeZipCode = value;

                }
                else
                {
                    throw new Exception("Zipcode must have at least 5 Digits.");
                }
            }
        }
        
        public string storeState { get; set; }
        public string storeAddress { get; set; }
        // private List<Products> _storeProducts;
        // public List<Products> storeproducts
        // {
        //     get{ return _storeProducts; }

        //     set 
        //     {
        //         if(value.Count <= 2)
        //         {
        //         _storeProducts = value;

        //         }
        //         else
        //         {
        //             throw new Exception("Customer List Must have 2 fields or less.");
        //         }

        //     }
        // }   
        // private List<Orders> _storeOrders;
        // public List<Orders> storeorders
        // {
        //     get{ return _storeOrders; }

        //     set 
        //     {
        //         if(value.Count <= 2)
        //         {
        //         _storeOrders = value;

        //         }
        //         else
        //         {
        //             throw new Exception("Customer List Must have 2 fields or less.");
        //         }

        //     }
        // }   

        //Default Class Constructor
        public StoreFronts()
        {
            storeNumber = 0;
            storeAddress = "";
            storeZipCode = "90210";
            storeState = "";
            // _storeOrders = new List<Orders>();
            // _storeProducts = new List<Products>();

        }

        public override string ToString()
        {
            return $"Store Number: {storeNumber}\n Store Address: {storeAddress}\nStore ZipCode: {storeZipCode}" +
            "$\nStore State: {storeState}";
        }

    }

}