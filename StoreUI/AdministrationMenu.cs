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
            Console.WriteLine("=[2] - Search For Customer                     =");
            Console.WriteLine("=[3] - Enter New StoreFront                    =");
            Console.WriteLine("=[4] - Search For StoreFront                   =");
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
                    return "NewCustomerMenu";
                case "2":
                    return "SearchCustomerMenu";
                case "3":
                    return "NewStoreFrontMenu";
                case "4":
                    return "SearchStoreFrontsMenu";
                default:
                    return "MainMenu";
            }
        }
    }
}