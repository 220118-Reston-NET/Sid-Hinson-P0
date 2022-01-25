
namespace StoreModel
{

    public class StoreFront
    {
        //Name of the StoreFront
        public string Name { get; set; }
        //Address of the Storefront
        public string Address { get; set; }
        //List that stores Products for the store
        //***I do not know why this wrong
        public List<Products> ProductList;
        //List that stores Orders for the store
        public List<Orders> StoreOrders;

    }

}