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
                   throw new NullReferenceException("Product has no name value.");
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

               if (value >= 0)
                {
                    _quantity = value;
                }
                else
                {
                    throw new Exception("A Quanitity equal or greater to Zero must be entered.");
                }
        
            }
        }


       //Default Constructor 
    public LineItems()
    {
      Product = "None";
      Quantity = 0;

    }

    }
}