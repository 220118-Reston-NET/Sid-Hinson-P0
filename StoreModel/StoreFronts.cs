
namespace StoreModel
{

    public class StoreFronts
    {
 
        public int storeNumber { get; set; }
        public string storeZipCode { get; set; }
        public string storeState { get; set; }
        public string storeAddress { get; set; }

        public string storeCity { get; set; }
        //Default Class Constructor
        public StoreFronts()
        {
            storeNumber = 0;
            storeAddress = "";
            storeZipCode = "";
            storeState = "";
            storeCity ="";
            // _storeOrders = new List<Orders>();
            // _storeProducts = new List<Products>();

        }

        public override string ToString()
        {
            return $"Store Number: {storeNumber}\nStore Address: {storeAddress}\nStore ZipCode: {storeZipCode}" +
            $"\nStore City: {storeCity}\nStore State: {storeState}";
        }

    }

}