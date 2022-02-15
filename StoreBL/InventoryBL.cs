using StoreModel;
using StoreDL;

namespace StoreBL
{
    public class InventoryBL : IInventoryBL
    {
        /// <summary>
        /// Dependency Injection Constructor
        /// </summary>
        private ISQLInventoryRepo _repo;
        public InventoryBL(ISQLInventoryRepo p_repo)
        {
            _repo = p_repo;
        }
        public Inventory AddInventory(Inventory p_inv)
        {
            List<Inventory> listofInventory = _repo.GetAllInventory();
            Console.WriteLine("Adding Inventory............");
            return _repo.AddInventory(p_inv);
          
    
        }

        public List<Inventory> SearchInventory(int p_storeID, int p_prodID) 
        {
            Console.WriteLine("Searching for Inventory Information ...........");
            List<Inventory> listofInventory = _repo.GetAllInventory();
            return listofInventory
                    .Where(Inventory => Inventory.StoreID.Equals(p_storeID))//Filter a collection with a Lamda
                    .Where(Inventory => Inventory.ProductID.Equals(p_prodID))//Filter a collection with a Lamda
                    .ToList(); //ToList method converts into return List collection
        }

        public Inventory FindItemLevel(int p_storeID, int p_prodID)
        {
            List<Inventory> listofInventory = _repo.GetAllInventory();
            Inventory FoundItem = new Inventory();
            foreach(Inventory item in listofInventory)
            {
                if(item.StoreID.Equals(p_storeID) & item.ProductID.Equals(p_prodID))
                {
                    FoundItem = item;
                    return FoundItem;
                }

            }
            
          return FoundItem;
        }

        public Inventory UpdateInventory(Inventory p_inv)
        {
            return _repo.UpdateInventory(p_inv);
        }

        public List<Inventory> GetAllInventory()
        {
            List<Inventory> listofinventory = _repo.GetAllInventory();
            return listofinventory;
        }
        
    }
}