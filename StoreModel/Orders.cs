namespace StoreModel
{
    public class Orders
    {
        //Customer Order Number
       //Maybe randomize an order number? Or assign it by order from 1? Check best practices
       //In backend SQL this is likely to be A Primary Key generated but we are not there yet
       private int _ordernumber;

       public int OrderNumber
       {
           get { return _ordernumber; }

           set {
                        if (value != 0)
                    {
                        _ordernumber = value;
                    }
                    else if (value == 0)
                    {
                        _ordernumber = 0;
                    }
                    else
                    {
                        throw new Exception("An Order number equal or greater to Zero must be entered.");
                    }
            
               }
               
        }


        //This is the Location of the StoreFront Ordered From
       public string StoreFrontLocation { get; set; }

       //List of Line Items for an Order
       private List<LineItems> _orderlineItems;
       public List<LineItems> OrderLineItems
        {
            get{ return _orderlineItems; }

            set 
            {

                _orderlineItems = value;

            }
        }   
        //Order total of Customer Order
       private double _ordertotal;

       public double OrderTotal
       {
           get { return _ordertotal; }

           set 
           {
               if (value != 0)
               {
                   _ordertotal = value;
               }
               else if (value == 0)
               {
                   _ordertotal = 0;
               }
               else
               {
                   throw new Exception("Price must equal or be greater to Zero.");
               }

           }

       }

      //Default Constructor
      
        public Orders()
        {
            OrderNumber = 0;
            StoreFrontLocation = "";
            OrderTotal = 0.00;
            
        }

    }
}