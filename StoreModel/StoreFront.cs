
namespace StoreModel
{

    public class StoreFront
    {
        //Name of the StoreFront
        public string Name { get; set; }
        //Address of the Storefront
        public string Address { get; set; }
        //List that stores Products for the store
        public List<Products> StoreProducts;
        //List that stores Orders for the store
        public List<Orders> StoreOrders;

        //Add Constructor Here

    }

}