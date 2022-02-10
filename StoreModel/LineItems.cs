namespace StoreModel
{
    public class LineItems
    {
       
       public string OrderID { get; set; }

       private int _productID;  
       public int ProductID
        {
            get
            {
                  return _productID;
            }
            set
            {
                 _productID = value;
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
                    throw new Exception("Quantity must equal or be greater to Zero.");
                }
        
            }
        }

        public int StoreID { get; set; }

        //Default Constructor 
        public LineItems()
        {
        
        ProductID = 0;
        ProductQuantity = 0;
        StoreID = 0;
        }
        
        public override string ToString()
        {
            return $"\nProductID: {ProductID}\nOrderID: {OrderID}" +
            $"\nProduct Quantity: {ProductQuantity}";
        }
    }
}