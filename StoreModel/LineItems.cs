namespace StoreModel
{
    public class LineItems
    {
        
       public string ProdCompany { get; set;}
       public int StoreID {get; set;}
       private string _productName;
       public string ProductName
       {
           get { return _productName; }
           
           set
           {
               if (value != "")
               {
                   _productName = value;
               }
               else
               {
                   throw new NullReferenceException("Product has no name value.");
               }
           }
       }

        //Quantity of Product
       private int _productQuantity;
       public int ProductQuantity
       {
           get { return _productQuantity; }
           
           set
           {

               if (value >= 0)
                {
                    _productQuantity = value;
                }
                else
                {
                    throw new Exception("A Quanitity equal or greater to Zero must be entered.");
                }
        
            }
        }
        public int ProductPrice {get; set;}

        //Default Constructor 
        public LineItems()
        {
        StoreID = 0;
        ProductName = "None";
        ProductName = "None";
        ProductPrice = 0;
        }
        
        public override string ToString()
        {
            return $"Product Name: {ProductName}\nStoreID: {StoreID}\nProduct Quantity: {ProductQuantity}\nProduct Price: {ProductPrice}";
        }
    }
}