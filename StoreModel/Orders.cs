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
       public List<LineItems> OrderLineItems;
        //Order total of Customer Order

       public double OrderTotal { get; set; }

      //Default Constructor      
        public Orders()
        {

            OrderID= "";
            CustomerID = "";
            StoreID = "";
            OrderDate = "";
            OrderTotal = 0.00;
            CustomerEmail = "";
            OrderLineItems = new List<LineItems>();


        }

        
        public override string ToString()
        {
            return $"OrderID: {OrderID}\nCustomerID: {CustomerID}\nStoreID: {StoreID}\nOrder Date: {OrderDate}" +
            $"\nOrderTotal: {OrderTotal}\nCustomerEmail : {CustomerEmail}";
        }
    }
}