
namespace StoreModel
{

    public class StoreFront
    {
        //Customer -> OrderNumber -> Order -> Line Items -> 



        //Name of the StoreFront
        public string Name { get; set; }
        //Address of the Storefront
        public string Address { get; set; }
        //List that stores Products for the store
        private List<Products> _storeproducts;
        public List<Products> StoreProducts
        {
            get{ return _storeproducts; }

            set 
            {
                if(value.Count <= 2)
                {
                _storeproducts = value;

                }
                else
                {
                    throw new Exception("Customer List Must have 2 fields or less.");
                }

            }
        }   
        //List that stores Orders for the store
        private List<Orders> _storeorders;
        public List<Orders> StoreOrders
        {
            get{ return _storeorders; }

            set 
            {
                if(value.Count <= 2)
                {
                _storeorders = value;

                }
                else
                {
                    throw new Exception("Customer List Must have 2 fields or less.");
                }

            }
        }   

        //Default Class Constructor
        public StoreFront()
        {
            Name = "";
            Address = "";
        }

    }

}