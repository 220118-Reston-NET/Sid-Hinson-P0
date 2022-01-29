using StoreModel;
using StoreBL;
namespace StoreUI
{
    public class UserMenu : IMenu
    {

        public void MenuDisplay()
        {
            Console.Clear();
            Console.WriteLine("================================================");
            Console.WriteLine("=               Customer Menu                  =");
            Console.WriteLine("================================================");
            Console.WriteLine("=          Enter Number to Select Option       =");     
            Console.WriteLine("================================================");
            Console.WriteLine("=[0] - Return to Main Menu / Exit              =");
            Console.WriteLine("=[1] - Enter New Customer                      ="); 
            Console.WriteLine("=[2] - Update Customer Information             =");
            Console.WriteLine("===============================================");
        }

        public string UserSelection()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    return "MainMenu";
                default:
                    return "AddCustomer";
            }
        }
    }
}