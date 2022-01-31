namespace StoreModel
{
    public class Orders
    {
        
       public string orderID { get; set; }

       public string customerID { get; set; }

       public string customerEmail { get; set; }

       public string storeID { get; set; }

       public string orderDate { get; set; }

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
            orderID = "";
            customerID = "";
            storeID = "";
            orderDate = "";
            orderTotal = 0.00;
            customerEmail = "";
            
        }

    }
}