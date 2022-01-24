namespace StoreModel
{
    public class Orders
    {
        
       private int OrderNumber;
       public string StoreFrontLocale { get; set; }
       private List<LineItems> OrderLineItems;
       private double _ordertotal;

    }
}