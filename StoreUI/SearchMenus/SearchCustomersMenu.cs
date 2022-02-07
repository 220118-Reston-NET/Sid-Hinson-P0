using StoreModel;
using StoreBL;
namespace StoreUI
{
    public class SearchCustomersMenu : IMenu
    {
        private ICustomersBL _custBL;

        public SearchCustomersMenu(ICustomersBL p_custBL)
        {
            _custBL = p_custBL; 
        }
        public void MenuDisplay()
        {   
            Console.Clear();
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
            string UserInput = Console.ReadLine();
            while(string.IsNullOrEmpty(UserInput))
            {
                Console.WriteLine("Selection must have an input. Please Enter a Menu selection.");
                UserInput =Console.ReadLine();

            }

            switch (UserInput)
            {
                case "0":
                    return "StoreMainMenu";


                case "1":
                    Console.WriteLine("Please Enter a First Name");
                    string p_Fname = Console.ReadLine();
                    while(string.IsNullOrEmpty(p_Fname))
                    {
                        Console.WriteLine("First Name must have an input. Please Enter a First Name");
                        p_Fname =Console.ReadLine();

                    }

                    Console.WriteLine("Please Enter a Last Name");
                    string p_Lname = Console.ReadLine();
                    while(string.IsNullOrEmpty(p_Lname))
                    {
                        Console.WriteLine("Last Name must have an input. Please Enter a Last Name");
                        p_Lname =Console.ReadLine();

                    }

                    Console.WriteLine("Please Enter an Email Address");
                    string p_Email = Console.ReadLine();
                    while(string.IsNullOrEmpty(p_Email))
                    {
                        Console.WriteLine("Email must have an input. Please Enter an Email Address");
                        p_Email =Console.ReadLine();

                    }

                    //***TODO***: Display Logic for Search Function - Add full iteration to actual method
                    List<Customers> listofcustomers = _custBL.SearchCustomers(p_Fname, p_Lname, p_Email);
                    foreach (var Customer in listofcustomers)
                    {
                        Console.WriteLine(Customer);
                    }
                    Console.WriteLine("Press Enter");
                    Console.ReadLine();
                    return "SearchCustomersMenu";


                default:
                    Console.WriteLine("Customer not Found");
                    Console.WriteLine("Press Enter");
                    Console.ReadLine();
                    return "StoreMainMenu";
            }
        }
    }
}