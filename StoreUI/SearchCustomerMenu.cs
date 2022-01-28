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
            Console.WriteLine("= [4] - Search By First Name & Last Name   =");
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
                    return "MainMenu";
                case "2":
                    return "MainMenu";
                case "3":
                    Console.WriteLine("Please Enter a Last Name");
                    string name = Console.ReadLine();
                    //Display Logic for Search Function
                    // List<Customer> listofcustomers = new List<Customer>();
                    // listofcustomers = _custBL.SearchCustomers(name);
                    List<Customer> listofcustomers = _custBL.SearchCustomers(name);
                    foreach (var Customer in listofcustomers)
                    {
                        Console.WriteLine(Customer);
                    }
                    Console.WriteLine("Press Enter");
                    Console.ReadLine();
                    return "MainMenu";
                case "4":
                    Console.WriteLine("Please Enter a First Name");
                    string name = Console.ReadLine();
                    Console.WriteLine("Please Enter a Last Name");
                    string name2 = Console.ReadLine();               
                    //Display Logic for Search Function
                    // List<Customer> listofcustomers = new List<Customer>();
                    // listofcustomers = _custBL.SearchCustomers(name);
                    List<Customer> listofcustomers = _custBL.SearchCustomers(name, name2);
                    foreach (var Customer in listofcustomers)
                    {
                        Console.WriteLine(Customer);
                    }
                    Console.WriteLine("Press Enter");
                    Console.ReadLine();              
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