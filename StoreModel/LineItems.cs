namespace StoreModel
{
    public class LineItems
    {
       private string _orderID;
       public string OrderID
        {
            get
            {
                  return _orderID;
            }
            set
            {
                 _orderID = value;
            }
        }


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
                    throw new Exception("Quanitity must equal or be greater to Zero.");
                }
        
            }
        }




        //Default Constructor 
        public LineItems()
        {
        
        OrderID = "";
        ProductID = 0;
        ProductQuantity = 0;

        }
        
        public override string ToString()
        {
            return $"\nProductID: {ProductID}\nOrderID: {OrderID}" +
            $"\nProduct Quantity: {ProductQuantity}";
        }
    }
}