using StoreModel;
using StoreDL;

namespace StoreBL
{
    public class StoreFrontsBL : IStoreFrontsBL
    {
        private ISQL_SRepository _repo;
        public StoreFrontsBL(ISQL_SRepository p_repo)
        {
            _repo = p_repo;
        }
        public StoreFronts AddStoreFronts(StoreFronts p_front)
        {
            List<StoreFronts> listofstorefronts = _repo.GetAllStoreFronts();
            if(listofstorefronts.Count < 20)
            {
                Console.WriteLine("Adding Store Front............");
                return _repo.AddStoreFronts(p_front);
            }
            else
            {
                throw new Exception("Limit of 20 objects is reached");
            }
        }

        public List<StoreFronts> SearchStoreFronts(int p_storeNumber) 
        {
            Console.WriteLine("Searching for Store Front Information ...........");
            List<StoreFronts> listofstorefronts = _repo.GetAllStoreFronts();
            return listofstorefronts
                    .Where(StoreFronts => StoreFronts.StoreID.Equals(p_storeNumber))//Filter a collection with a Lamda
                    .ToList(); //ToList method converts into return List collection
        }

        public List<StoreFronts> GetAllStoreFronts()
        {
            List<StoreFronts> listofstorefronts = _repo.GetAllStoreFronts();
            return listofstorefronts;
        }

        public List<StoreFronts> GetCompStoreHist(int p_store)
        {
            return _repo.GetCompStoreHist(p_store);
        }
        
    }
}