using StoreModel;
using StoreBL;
namespace StoreUI
{
    public class SearchCustomersMenu : IStoreMenu
    {
        private IStoreBL _custBL;

        public SearchCustomersMenu(IStoreBL p_custBL)
        {
            _custBL = p_custBL; 
        }
        public void MenuDisplay()
        {   
            Console.WriteLine("============================================");
            Console.WriteLine("=          Menu : Search Customers          ");
            Console.WriteLine("============================================");
            Console.WriteLine("=              Select Option :             =");
            Console.WriteLine("= [0] - Exit Search                        =");
            Console.WriteLine("= [1] - Search By Email                    =");
            Console.WriteLine("= [2] - Search By Address                  =");
            Console.WriteLine("= [3] - Search By Last Name                =");
            Console.WriteLine("= [4] - Search By Phone Number             =");
            Console.WriteLine("= [5] - Search By Phone# & Last Name       =");
            Console.WriteLine("============================================");
        }

        public string UserSelection()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return "MainMenu";
                case "1":
                    Console.WriteLine("Awaiting Implementation");
                    return "MainMenu";
                case "2":
                    Console.WriteLine("Awaiting Implementation");
                    return "MainMenu";
                case "3":
                    Console.WriteLine("Please Enter a Last Name");
                    string name = Console.ReadLine();
                    //Display Logic for Search Function
                    List<Customer> newlistofcustomers = _custBL.SearchCustomers(name);
                    foreach (var Customer in newlistofcustomers)
                    {
                        Console.WriteLine(Customer.ToString);
                    }
                    Console.WriteLine("Press Enter");
                    Console.ReadLine();
                    return "MainMenu";
                case "4":
                    Console.WriteLine("Please Enter a Phone Number");
                    string phone = (Console.ReadLine());
                    Console.WriteLine("Awaiting Implementation");
                    Console.WriteLine("Press Enter");
                    Console.ReadLine();
                    return "MainMenu";
                case "5":
                    Console.WriteLine("Awaiting Implementation");
                    return "MainMenu";
                default:
                    Console.WriteLine("Selection Invalid");
                    Console.WriteLine("Press Enter");
                    Console.ReadLine();
                    return "MainMenu";
            }
        }
    }
}