using System.Data.SqlClient;
using StoreModel;
namespace StoreDL
{
    public interface ISQLCustomersRepo
    {
        /// <summary>
        /// Add Customers to DB
        /// </summary>
        /// <param name="p_cust"></param> Customer Object
        /// <returns>Customer Added</returns>
        Customers AddCustomers(Customers p_cust);
        /// <summary>
        /// Will Get All Customers in DB
        /// </summary>
        /// <returns>Returns List</returns>
        List<Customers> GetAllCustomers();
    }
    
        public interface ISQLProductsRepo
    {
        /// <summary>
        /// Add Products to DB
        /// </summary>
        /// <param name="p_prod"></param> Customer Object
        /// <returns>Product Added</returns>
        Products AddProducts(Products p_prod);

        /// <summary>
        /// Will Get All Products in DB
        /// </summary>
        /// <returns>Returns List</returns>
        List<Products> GetAllProducts();
    }
    
        public interface ISQLStoreFrontsRepo
    {
        /// <summary>
        /// Add Storefronts to DB
        /// </summary>
        /// <param name="p_store"></param> Customer Object
        /// <returns>Storefront Added</returns>
        StoreFronts AddStoreFronts(StoreFronts p_store);
        /// <summary>
        /// Will Get All Storefronts in DB
        /// </summary>
        /// <returns>Returns List</returns>
        List<StoreFronts> GetAllStoreFronts();
    }
    
        public interface ISQLOrdersRepo
    {
        /// <summary>
        /// Add Orders to DB
        /// </summary>
        /// <param name="p_ord"></param> Customer Object
        /// <returns>Order Added</returns>
        Orders AddOrders(Orders p_ord);
        /// <summary>
        /// Will Get All Orders in DB
        /// </summary>
        /// <returns>Returns List</returns>
        List<Orders> GetAllOrders();
    }
    
}