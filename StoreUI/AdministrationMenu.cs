using StoreModel;
using StoreBL;
namespace StoreUI
{
    public class AdministrationMenu : IMenu
    {
        public void MenuDisplay()
        {
            Console.Clear();
            Console.WriteLine("================================================");
            Console.WriteLine("=             Administration Menu               =");
            Console.WriteLine("================================================");
            Console.WriteLine("=               Select Option                   =");     
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
                    return "MainMenu";
            }
        }
    }
}