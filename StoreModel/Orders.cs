namespace StoreModel
{
    public class Orders
    {
        
       public string OrderID { get; set; }

       public int OrderCustID { get; set; }

       public int OrderStoreID { get; set; }

       public string OrderDate { get; set; }

       public string OrderStatus { get; set; }


       //List of Line Items for an Order, Line Items is a String/int type
       //May need to be ArrayList or something else
       public List<LineItems> OrderLineItems { get; set;}
        //Order total of Customer Order
       public double OrderTotal { get; set; }
      //Default Constructor      
        public Orders()
        {

            OrderID = "";
            OrderCustID = 0;
            OrderStoreID = 0;
            OrderDate = "";
            OrderTotal = 0.00;
            OrderLineItems = new List<LineItems>(){ new LineItems() };
            OrderStatus = "";
        
        }
        public override string ToString()
        {
            return $"OrderID: {OrderID}\nCustomerID: {OrderCustID}\nStoreID: {OrderStoreID}\nOrder Date: {OrderDate}" +
            $"\nOrderTotal: {OrderTotal}\nOrder Items{OrderLineItems}";
        }

        public string AlsoToString()
        {
            return $"{OrderLineItems}";
        }
    }
}