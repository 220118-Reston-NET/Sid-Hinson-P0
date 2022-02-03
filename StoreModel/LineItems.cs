namespace StoreModel
{
    public class LineItems
    {
       public int ProductID {get; set; }
       public string ProductCompany { get; set;}
       public int StoreID {get; set;}
       private string _ProductName;
       public string ProductName
       {
           get { return _ProductName; }
           
           set
           {
               if (value != "")
               {
                   _ProductName = value;
               }
               else
               {
                   throw new NullReferenceException("Product has no name value.");
               }
           }
       }

        //Quantity of Product
       private int _ProductQuantity;
       public int ProductQuantity
       {
           get { return _ProductQuantity; }
           
           set
           {

               if (value >= 0)
                {
                    _ProductQuantity = value;
                }
                else
                {
                    throw new Exception("A Quanitity equal or greater to Zero must be entered.");
                }
        
            }
        }
        public double ProductPrice {get; set;}

        //Default Constructor 
        public LineItems()
        {
        
        ProductID = 0;
        StoreID = 0;
        ProductName = "None";
        ProductCompany = "None";
        ProductPrice = 0;
        ProductQuantity = 0;
        }
        
        public override string ToString()
        {
            return $"\nProductID: {ProductID}\nProduct Name: {ProductName}\nStoreID: {StoreID}\nProduct Company: {ProductCompany}" +
            $"\nProduct Quantity: {ProductQuantity}\nProduct Price: {ProductPrice}";
        }
    }
}