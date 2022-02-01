namespace StoreModel
{
    public class Orders
    {
        
       public string OrderID { get; set; }

       public string CustomerID { get; set; }

       public string CustomerEmail { get; set; }

       public string StoreID { get; set; }

       public string OrderDate { get; set; }

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

       public double OrderTotal
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
            OrderID = "";
            CustomerID = "";
            StoreID = "";
            OrderDate = "";
            OrderTotal = 0.00;
            OrderLineItems = new List<LineItems>() { new LineItems() };
        }

        
        public override string ToString()
        {
            return $"OrderID: {OrderID}\nCustomerID: {CustomerID}\nStoreID: {StoreID}\nOrder Date: {OrderDate}" +
            $"\nOrderTotal: {OrderTotal}";
        }
    }
}