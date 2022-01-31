namespace StoreModel
{
    public class Products
    {
        public string productID { get; set; }

        public int storeNumber { get; set; }
        //Product Name
        public string productName { get; set; }
        public string productCompany { get; set; }
        //Product Price
        public double productPrice { get; set; }
        //Product Description
        public string productDescription { get; set; }
        //Product Category 
        public string productCategory { get; set; }

        public int productQuantity { get; set; }

        //Default Constructor

        public Products()
        {
            productID ="";
            storeNumber = 0;
            productName = "";
            productCompany ="";
            productPrice = 0.00;
            productDescription = "";
            productCategory = "";
            productQuantity = 0;
        }

    public override string ToString()
    {
      return $"Product Id: {productID}\nStore Number: {storeNumber} Name: {productName}" +
      $"\nPrice: {productPrice}\nDes: {productDescription}\nCategory: {productCategory}" +
      $"\nCompany: {productCompany}\nQuantity: {productQuantity}";
    }

    }

}