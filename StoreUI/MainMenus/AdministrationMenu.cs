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
            Console.WriteLine("=[5] - Enter New Product                       =");
            Console.WriteLine("=[6] - Search For Product                      =");
            Console.WriteLine("================================================");
        }

        public string UserSelection()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    return "StoreMainMenu";
                case "1":
                    return "NewCustomersMenu";
                case "2":
                    return "SearchCustomersMenu";
                case "3":
                    return "NewStoreFrontsMenu";
                case "4":
                    return "SearchStoreFrontsMenu";
                case "5":
                    return "AddNewProductsMenu";
                case "6":
                    return "SearchProductsMenu";
                case "7":
                    return "DisplayAllProdsStoreMenu";
                default:
                    return "NewCustomersMenu";
            }
        }
    }
}