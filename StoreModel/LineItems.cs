namespace StoreModel
{
    public class LineItems
    {
       private int _orderID;
       public int OrderID
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

 
       private string _ProductName;
       public string ProductName
       {
           get { return _ProductName; }
           
           set
           {
               if (string.IsNullOrEmpty(value))
               {
                    throw new NullReferenceException("Product Must Have a Name.");
               }
               else
               {
                   _ProductName = value;

               }
           }
       }
       
       private string _orderDate;
       public string OrderDate
       {
           get { return _orderDate; }

           set
           {
                int length = value.Length;

                if (string.IsNullOrEmpty(value))
                {
                        throw new NullReferenceException("Please Enter a ZipCode");
                }
                else if(value.Length == 8)
                {
                    _orderDate = value;
                }
                else
                {
                    throw new Exception("Order date must be 8 characters i.e. 10211980 format : MMDDYYYY");
 
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
                    throw new Exception("Quanitity must equal or be greater to Zero.");
                }
        
            }
        }


        private double _productPrice;
        public double ProductPrice
        {
           get { return _ProductQuantity; }
           
           set
           {

               if (value >= 0)
                {
                    _productPrice = value;
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
        
        OrderID = 0;
        ProductID = 0;
        StoreID = 0;
        ProductName = "None";
        ProductPrice = 0;
        ProductQuantity = 0;
        OrderDate = "10211980";

        }
        
        public override string ToString()
        {
            return $"\nProductID: {ProductID}\nProduct Name: {ProductName}\nStoreID: {StoreID}\nOrderID: {OrderID}" +
            $"\nProduct Quantity: {ProductQuantity}\nProduct Price: {ProductPrice}";
        }
    }
}