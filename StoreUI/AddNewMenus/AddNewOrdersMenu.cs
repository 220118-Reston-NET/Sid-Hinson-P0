using StoreModel;
using StoreBL;
namespace StoreUI
{
    public class AddNewOrdersMenu : IMenu
    {
        //Dependency Injection
        private IProductsBL _productBL;
        private IOrdersBL _orderBL;
        private ICustomersBL _customerBL;
        
        public AddNewOrdersMenu(IOrdersBL p_orderBL, IProductsBL p_productBl, ICustomersBL p_customerBL)
        {
            _orderBL = p_orderBL;
            _productBL = p_productBl;
            _customerBL = p_customerBL;
        }
        public void MenuDisplay()
        {
            Console.Clear();
            Console.WriteLine("================================================");
            Console.WriteLine("=    Retro Barbarian Gaming Lair Shop Menu     =");
            Console.WriteLine("================================================");
            Console.WriteLine("=         Enter Number to Select Option        =");     
            Console.WriteLine("================================================");
            Console.WriteLine("=[0] - Return to Main Menu / Exit              =");
            Console.WriteLine("=[1] - Display Product By Category             =");
            Console.WriteLine("=[2] - Search For Products by Criteria         =");
            Console.WriteLine("=[3] - Create/Edit Product Order               =");
            Console.WriteLine("=[4] - View Order History                      =");
            Console.WriteLine("================================================");
        }

        public string UserSelection()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                //Return to Main Menu
                case "0":
                return "StoreMainMenu";


                //Display Products by Category
                case "1":
                return "AddProductsDisplay";

                //Search Products by Criteria
                case "2":
                return "SearchProductsMenu"; 


                //Create Edit Orders
                //Implement ***********
                case "3":
                return "NewCustomerOrderMenu";


                //View Order History
                //Implement ***********
                case "4":
                return "NewCustomerOrderMenu";

                //Default Case
                default:
                return "AddNewOrdersMenu";
            }
        }
    }
}