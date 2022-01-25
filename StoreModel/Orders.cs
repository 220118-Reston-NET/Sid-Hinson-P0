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
                        if (value > 0)
                    {
                        _ordernumber = value;
                    }
                    else
                    {
                        throw new Exception("An Order number equal or greater to Zero must be entered.");
                    }
            
               }
               
        }


        //This is the Location of the StoreFront Ordered From
       public string StoreFrontLocation { get; set; }

       //List of Line Items for an Order, Line Items is a String/int type
       //May need to be ArrayList or something else
       private List<LineItems> _orderlineItems;
       public List<LineItems> OrderLineItems
        {
            get{ return _orderlineItems; }

            set 
            {
                if(value.Count <= 3)
                {
                _orderlineItems = value;

                }
                else
                {
                    throw new Exception("Customer List Must have 3 fields or less.");
                }

            }
        }   
        //Order total of Customer Order
       private double _ordertotal;

       public double OrderTotal
       {
           get { return _ordertotal; }

           set 
           {
                if (value >= 0.00)
            {
                value = _ordertotal;
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
            OrderNumber = 0;
            StoreFrontLocation = "";
            OrderTotal = 0.00;
            _orderlineItems = new List<LineItems>()
            {
                new LineItems()
            };
        }

    }
}