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
        public Customers AddCustomers(Customers p_cust);
        /// <summary>
        /// Will Get All Customers in DB
        /// </summary>
        /// <returns>Returns List</returns>
        public List<Customers> GetAllCustomers();
    }
    
        public interface ISQLProductsRepo
    {
        /// <summary>
        /// Add Products to DB
        /// </summary>
        /// <param name="p_prod"></param> Customer Object
        /// <returns>Product Added</returns>
        public Products AddProducts(Products p_prod);

        /// <summary>
        /// Will Get All Products in DB
        /// </summary>
        /// <returns>Returns List</returns>
        public List<Products> GetAllProducts();

    }
    
        public interface ISQLStoreFrontsRepo
    {
        /// <summary>
        /// Add Storefronts to DB
        /// </summary>
        /// <param name="p_store"></param> Customer Object
        /// <returns>Storefront Added</returns>
        public StoreFronts AddStoreFronts(StoreFronts p_store);
        /// <summary>
        /// Will Get All Storefronts in DB
        /// </summary>
        /// <returns>Returns List</returns>
        public List<StoreFronts> GetAllStoreFronts();
    }
    
        public interface ISQLOrdersRepo
    {
        /// <summary>
        /// Add Orders to DB
        /// </summary>
        /// <param name="p_ord"></param> Customer Object
        /// <returns>Order Added</returns>
        public Orders AddOrders(Orders p_ord);
        /// <summary>
        /// Will Get All Orders in DB
        /// </summary>
        /// <returns>Returns List</returns>
        public List<Orders> GetAllOrders();
        public LineItems AddLineItems(LineItems p_line);

        public List<LineItems> GetAllLineItems();

    }
    

        public interface ISQLInventoryRepo
    {
        /// <summary>
        /// Adds Inventory to DB
        /// </summary>
        /// <param name="p_inv"></param>
        /// <returns>inventory obj</returns>
        public Inventory AddInventory(Inventory p_inv);
        /// <summary>
        /// Gets All Inventory
        /// </summary>
        /// <returns></returns>
        public List<Inventory> GetAllInventory();

        // public Inventory UpdateInventory(Inventory p_inv);

    }
}