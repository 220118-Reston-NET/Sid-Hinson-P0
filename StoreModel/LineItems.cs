namespace StoreModel
{
    public class LineItems
    {
        //Product Name
       private string _product;
       public string Product
       {
           get { return _product; }
           
           set
           {
               if (value != "")
               {
                   _product = value;
               }
               else
               {
                   throw new NullReferenceException("Email must be entered.");
               }
           }


       }

        //Quantity of Product
       private int _quantity;
       public int Quantity
       {
           get { return _quantity; }
           
           set
           {
               if (value != 0)
               {
                   _quantity = value;
               }
               else if (value == 0)
               {
                   _quantity = 0;
               }
               else
               {
                   throw new Exception("A whole number equal or greater to Zero must be entered.");
               }
           }

       }


       //Default Constructor 
    public LineItems()
    {
      Product = "";
      Quantity = 0;

    }

    }
}