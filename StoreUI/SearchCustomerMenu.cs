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
            Console.WriteLine("= [1] - Search By Last Name                =");
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
                    Console.WriteLine("Please Enter a Name");
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
                default:
                    Console.WriteLine("Selection Invalid");
                    Console.WriteLine("Press Enter");
                    Console.ReadLine();
                    return "MainMenu";
            }
        }
    }
}