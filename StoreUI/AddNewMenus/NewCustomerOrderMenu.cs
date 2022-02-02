using StoreModel;
using StoreBL;
namespace StoreUI
{
    public class NewCustomerOrderMenu : IMenu
    {
        //Static Class for variable Consistently Across the Created Class Objects
        public static LineItems p_LineToOrder = new LineItems();
        private static Orders p_NewOrder = new Orders();
        //Dependency Injection
        private IProductsBL _productBL;
        private IOrdersBL _orderBL;
        private ICustomersBL _customerBL;
        
        public NewCustomerOrderMenu(IOrdersBL p_orderBL, IProductsBL p_productBl, ICustomersBL p_customerBL)
        {
            _orderBL = p_orderBL;
            _productBL = p_productBl;
            _customerBL = p_customerBL;
        }
        public void MenuDisplay()
        {
            Console.Clear();
            Console.WriteLine("================================================");
            Console.WriteLine("=             Menu : Add Customer              =");
            Console.WriteLine("===============================================");
            Console.WriteLine("=       Enter New Order Info : Select          =");     
            Console.WriteLine("================================================");
            Console.WriteLine("=[0] -Return to Main Menu"); 
            Console.WriteLine("*[1]  Store # - " + p_NewOrder.OrdStoreID);
            Console.WriteLine("*[2]  Product Name - " + p_LineToOrder.ProductName);
            Console.WriteLine("*[3]  Product Company - " + p_LineToOrder.ProdCompany);
            Console.WriteLine("*[3]  Quantity - " + p_LineToOrder.ProductQuantity);      
            Console.WriteLine("*[5]  Customer Email - " + p_NewOrder.OrdCustEmail);
            Console.WriteLine("=[6] Update & Save Information");
            Console.WriteLine("===============================================");
        }
        
        public string UserSelection()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    return "StoreMainMenu";
                case "1":
                    Console.WriteLine("Enter a Store ID :");
                    p_NewOrder.OrdStoreID = Console.ReadLine();
                    return "NewCustomerorderMenu";
                case "2":
                    Console.WriteLine("Enter a Product Name : ");
                    p_LineToOrder.ProductName = Console.ReadLine();
                    return "NewCustomerorderMenu";
                case "3":
                    Console.WriteLine("Enter a Product Company :");
                    p_LineToOrder.ProdCompany = Console.ReadLine();
                    return "NewCustomerorderMenu";
                case "4":
                    Console.WriteLine("Enter an Product Quantity : ");
                    p_LineToOrder.ProductQuantity = Convert.ToInt32(Console.ReadLine());
                    return "NewCustomerorderMenu";

                case "5":
                    Console.WriteLine("Enter Customer Email :");
                    p_NewOrder.OrdCustEmail = Console.ReadLine();
                    return "NewCustomerorderMenu";
                case "6":
                    try
                    {   
                        _orderBL.AddOrders(p_NewOrder);

                    }
                    catch (System.Exception exc)
                    {
                        Console.WriteLine(exc.Message);
                        Console.WriteLine("Something Unexpected Happened");
                        Console.WriteLine("Press Enter to Continue");
                        Console.ReadLine();
                    }
                    return "NewCustomerOrderMenu";
                    default:
                    return "NewCustomerOrderMenu";
            }
        }
    }
}