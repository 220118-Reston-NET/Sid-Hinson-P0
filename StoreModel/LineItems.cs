namespace StoreModel
{
    public class LineItems
    {
        //Product Name
       private string _productName;
       public string productName
       {
           get { return _productName; }
           
           set
           {
               if (value != "")
               {
                   _productName = value;
               }
               else
               {
                   throw new NullReferenceException("Product has no name value.");
               }
           }
       }

        //Quantity of Product
       private int _productQuantity;
       public int productQuantity
       {
           get { return _productQuantity; }
           
           set
           {

               if (value >= 0)
                {
                    _productQuantity = value;
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
      productName = "None";
      productQuantity = 0;

    }

    }
}