namespace StoreModel
{
    public class Products
    {
        //Need a Product ID *****
        public int productNumber { get; set; }
        //Product Name
        public string productName;
        //Product Price
        public double productPrice;
        //Product Description
        public string productDescription;
        //Product Category 
        public string productCategory;

        //Default Constructor

        public Products()
        {
            productName = "";
            productPrice = 0.00;
            productDescription = "";
            productCategory = "";
            productNumber =0;
        }

    }

}