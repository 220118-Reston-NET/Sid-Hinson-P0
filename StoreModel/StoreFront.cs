namespace StoreModel
{
    public class StoreFront
    {
       public string Name { get; set; }
       public string Address { get; set; }
       public List<Products> StoreProducts;
       private List<Orders> _storeorders;
       
    }
}