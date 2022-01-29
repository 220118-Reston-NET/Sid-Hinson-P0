namespace StoreModel
{
    public class Orders
    {
        //Customer Order Number
       //Maybe randomize an order number? Or assign it by order from 1? Check best practices
       //In backend SQL this is likely to be A Primary Key generated but we are not there yet
       private int _orderNumber;

       public int orderNumber
       {
           get { return _orderNumber; }

           set {
                        if (value >= 0)
                    {
                        _orderNumber = value;
                    }
                    else
                    {
                        throw new Exception("An Order number equal or greater to Zero must be entered.");
                    }
            
               }
               
        }


        //This is the Location of the StoreFront Ordered From
       public int storeNumber { get; set; }

       //List of Line Items for an Order, Line Items is a String/int type
       //May need to be ArrayList or something else
       private List<LineItems> _orderLineItems;
       public List<LineItems> OrderLineItems
        {
            get{ return _orderLineItems; }

            set 
            {
                if(value.Count <= 3)
                {
                _orderLineItems = value;

                }
                else
                {
                    throw new Exception("Customer List Must have 3 fields or less.");
                }

            }
        }   
        //Order total of Customer Order
       private double _orderTotal;

       public double orderTotal
       {
           get { return _orderTotal; }

           set 
           {
                if (value >= 0.00)
            {
                value = _orderTotal;
            }
            else
            {
                throw new Exception("An Order number equal or greater to Zero must be entered.");
            }
        }

       }


      //Default Constructor      
        public Orders()
        {
            orderNumber = 0;
            storeNumber = 0;
            orderTotal = 0.00;
        }

    }
}