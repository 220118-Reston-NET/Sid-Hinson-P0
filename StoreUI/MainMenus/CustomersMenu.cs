using StoreModel;
using StoreBL;
namespace StoreUI
{
    public class CustomersMenu : IMenu
    {

        public void MenuDisplay()
        {
            Console.Clear();
            Console.WriteLine("=========================================================="); 
            Console.WriteLine(")xxxxx[;;;;;;;;;>    )xxxxx[;;;;;;;;;>   )xxxxx[;;;;;;;;;>"); 
            Console.WriteLine("==========================================================");
            Console.WriteLine("==========================================================");
            Console.WriteLine("=                     Customer Menu                      =");
            Console.WriteLine("==========================================================");
            Console.WriteLine("=              Enter Number to Select Option             =");     
            Console.WriteLine("==========================================================");
            Console.WriteLine("=          [0] - Return to Main Menu / Exit              =");
            Console.WriteLine("=          [1] - Enter New Customer                      =");
            Console.WriteLine("=          [2] - Search For StoreFront                   =");
            Console.WriteLine("=          [3] - Products & Orders Viewing               =");
            Console.WriteLine("=          [4] - Order Products Menu                     =");
            Console.WriteLine("==========================================================");
        }

        public string UserSelection()
        {
            Log.Information("User is selecting an input");
            string userInput = Console.ReadLine();
            while(string.IsNullOrEmpty(userInput))
            {
                Log.Information("User is retrying to select an input");
                Console.WriteLine("Please Input a Selection");
                userInput = Console.ReadLine();
            }
            switch (userInput)
            {
                case "0":
                    Log.Information("User is selecting Store Main Menu");
                    return "StoreMainMenu";
                case "1":
                    Log.Information("User is selecting New Customers Menu");
                    return "NewCustomersMenu";
                case "2":
                    Log.Information("User is selecting Search Store Fronts Menu");
                    return "SearchStoreFrontsMenu";
                case "3":
                    Log.Information("User is selecting Add Business Transaction Menu");
                    return "AddBusinessTransaction";               
                case "4":
                    Log.Information("User is selecting Add New Order Menu");
                    return "AddNewOrderMenu";                    
                default:
                    Log.Information("User has made an invalid selection");
                    Console.WriteLine("Invalid Selection. Please Try Again. Press Enter to Continue");
                    Console.ReadLine();
                    return "StoreMainMenu";
            }
        }
    }
}