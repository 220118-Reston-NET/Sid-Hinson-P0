using StoreModel;
using StoreBL;
namespace StoreUI
{
    public class CustomersMenu : IMenu
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
            Console.WriteLine("=[2] - Search For StoreFront                   ="); 
            Console.WriteLine("================================================");
        }

        public string UserSelection()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    return "MainMenu";
                case "1":
                    return "NewCustomersMenu";
                case "2":
                    return "MainMenu";
                default:
                    return "MainMenu";
            }
        }
    }
}