using StoreModel;
using StoreBL;
namespace StoreUI
{
    public class AddNewOrdersMenu : IOrdersMenu
    {
        private static Orders _newOrder = new Orders();
        //Dependency Injection
        private ICustomersBL _orderBL;
        //
        public AddNewOrdersMenu(ICustomersBL p_orderBL)
        {
            _orderBL = p_orderBL;
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
            Console.WriteLine("=[1] - Enter Last Name & Pass For Shopping     =");
            Console.WriteLine("=[2] - Display Individual Store Front Products =");  
            Console.WriteLine("=[2] - Order Your Products                     =");
            Console.WriteLine("=[3] - Display / Remove Products From Order    =");
            Console.WriteLine("=[4] - Remove ALL Products From Order          =");
            Console.WriteLine("=[5] - Finalize Customer Order                 =");
            Console.WriteLine("================================================");
        }

        public string UserSelection()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                return "AddNewOrdersMenu";
                case "2":
                return "AddNewOrdersMenu";
                case "3":
                return "AddNewOrdersMenu";
                case "4":
                return "AddNewOrdersMenu";
                case "5":
                return "AddNewOrdersMenu";
                case "6":
                return "AddNewOrdersMenu";
                default:
                return "AddNewOrdersMenu";
            }
        }
    }
}