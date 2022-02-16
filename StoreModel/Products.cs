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

        //Default Constructor

        public Products()
        {
            StoreID = 0;
            ProductName = "SNES";
            ProductCompany ="NINTENDO";
            ProductPrice = 200.00;
            ProductDescription = "RETRO GAMING SYSTEM";
            ProductCategory = "SYSTEM";
        }

    public override string ToString()
    {
      return $"Product Id: {ProductID}\nStore Number: {StoreID}\nName: {ProductName}" +
      $"\nPrice: {ProductPrice}\nDes: {ProductDescription}\nCategory: {ProductCategory}" +
      $"\nCompany: {ProductCompany}";
    }

    }

}