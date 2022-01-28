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
            Console.WriteLine("=          Menu : Search Customers         =");
            Console.WriteLine("============================================");
            Console.WriteLine("=              Select Option :             =");
            Console.WriteLine("= [0] - Exit Search                        =");
            Console.WriteLine("= [1] - Find Customer                      =");
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
                    Console.WriteLine("Please Enter a First Name");
                    string p_fname = Console.ReadLine();
                    Console.WriteLine("Please Enter a Last Name");
                    string p_lname = Console.ReadLine();
                    Console.WriteLine("Please Enter an Email Address");
                    string p_email = Console.ReadLine();
                    //Display Logic for Search Function
                    List<Customer> listofcustomers3 = _custBL.SearchCustomers(p_fname, p_lname, p_email);
                    foreach (var Customer in listofcustomers3)
                    {
                        Console.WriteLine(Customer);
                    }
                    Console.WriteLine("Press Enter");
                    Console.ReadLine();
                    return "MainMenu";
                default:
                    Console.WriteLine("Customer not Found");
                    Console.WriteLine("Press Enter");
                    Console.ReadLine();
                    return "MainMenu";
            }
        }
    }
}