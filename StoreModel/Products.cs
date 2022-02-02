namespace StoreModel
{
    public class Products
    {
        public int ProductID { get; set; }

        public int StoreID { get; set; }
        //Product Name
        public string ProductName { get; set; }
        public string ProductCompany { get; set; }
        //Product Price
        public double ProductPrice { get; set; }
        //Product Description
        public string ProductDescription { get; set; }
        //Product Category 
        public string ProductCategory { get; set; }

        public int ProductQuantity { get; set; }

        //Default Constructor

        public Products()
        {
            ProductID = 0;
            StoreID = 0;
            ProductName = "";
            ProductCompany ="";
            ProductPrice = 0.00;
            ProductDescription = "";
            ProductCategory = "";
            ProductQuantity = 0;
        }

    public override string ToString()
    {
      return $"Product Id: {ProductID}\nStore Number: {StoreID}\n Name: {ProductName}" +
      $"\nPrice: {ProductPrice}\nDes: {ProductDescription}\nCategory: {ProductCategory}" +
      $"\nCompany: {ProductCompany}\nQuantity: {ProductQuantity}";
    }

    }

}