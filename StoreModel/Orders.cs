namespace StoreModel
{
    public class Orders
    {
        
       //Maybe randomize an order number? Or assign it by order from 1? Check best practices
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

       //Possibly implement Private List for Data Privacy
       public List<LineItems> OrderLineItems;
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

      //Add Constructor here

    }
}