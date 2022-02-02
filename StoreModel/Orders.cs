namespace StoreModel
{
    public class Orders
    {
        
       public string OrderID { get; set; }

       public string OrdCustID { get; set; }

       public string OrdCustEmail { get; set; }

       public string OrdStoreID { get; set; }

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
            OrdCustID = "";
            OrdStoreID = "";
            OrderDate = "";
            OrderTotal = 0.00;
            OrdCustEmail = "";
            OrderLineItems = new List<LineItems>();


        }

        
        public override string ToString()
        {
            return $"OrderID: {OrderID}\nCustomerID: {OrdCustID}\nStoreID: {OrdStoreID}\nOrder Date: {OrderDate}" +
            $"\nOrderTotal: {OrderTotal}\nCustomerEmail : {OrdCustEmail}";
        }
    }
}