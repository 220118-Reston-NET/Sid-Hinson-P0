
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

                _storeproducts = value;

            }
        }   
        //List that stores Orders for the store
        private List<Orders> _storeorders;
        public List<Products> StoreOrders
        {
            get{ return _storeproducts; }

            set 
            {

                _storeproducts = value;

            }
        }   

        //How to implement constructor List? Research this or see if that's even correct to do.
        //Default Class Constructor
        public StoreFront()
        {
            Name = "";
            Address = "";
            
        }

    }

}