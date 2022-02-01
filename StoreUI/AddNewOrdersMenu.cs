using StoreModel;
using StoreBL;
namespace StoreUI
{
    public class AddNewOrdersMenu : IMenu
    {
        private static LineItems _newLineItem = new LineItems();
        private static Orders _newOrder = new Orders();
        public static string p_CustomerEmail;
        public static string p_CustomerID;
        public static string p_Company;
        //Dependency Injection
        private IProductsBL _productBL;
        private IOrdersBL _orderBL;
        private ICustomersBL _customerBL;
        
        public AddNewOrdersMenu(IOrdersBL p_orderBL, IProductsBL p_productBl, ICustomersBL p_customerBL)
        {
            _orderBL = p_orderBL;
            _productBL = p_productBl;
            _customerBL = p_customerBL;
        }
        public void MenuDisplay()
        {
            Console.Clear();
            Console.WriteLine("================================================");
            Console.WriteLine("=    Retro Barbarian Gaming Lair Shop Menu     =");
            Console.WriteLine("================================================");
            Console.WriteLine("=         Enter Number to Select Option        =");     
            Console.WriteLine("================================================");
            Console.WriteLine("=[0] - Return to Main Menu / Exit              =");
            Console.WriteLine("=[1] - Enter Last Name & Pass For Shopping     =");
            Console.WriteLine("=[2] - Display Product By Category             =");  
            Console.WriteLine("=[3] - Order Your Products                     =");
            Console.WriteLine("=[4] - Display / Remove Products From Order    =");
            Console.WriteLine("=[5] - Remove ALL Products From Order          =");
            Console.WriteLine("=[6] - Save Customer Order                     =");
            Console.WriteLine("================================================");
        }

        public string UserSelection()
        {
            string userInput = Console.ReadLine();

            //**********************************WORK IN PROGRESS*******************************
            //********todo:Convert these Switch Statements into BL void/return Methods*********
            //********todo: Make Display pages for Some of these ******************************
            //*************Code here is to just get the program to a working state*************
            //*********************************************************************************

            switch (userInput)
            {
                case "0":
                return "StoreMainMenu";



                case "1":
                Console.WriteLine("Please Enter a First Name");
                string p_fname = Console.ReadLine();
                Console.WriteLine("Please Enter a Last Name");
                string p_lname = Console.ReadLine();
                Console.WriteLine("Enter Customer Email Address");
                p_CustomerEmail = Console.ReadLine();
                List<Customers> listofcustomers = _customerBL.SearchCustomers(p_fname, p_lname, p_CustomerEmail);
                try
                {            //******************************This is Broke*****************************
                foreach (var Customer in listofcustomers)
                {
                    Console.WriteLine("Saving CustomerID to Order.......");
                    Customer.CustomerID = p_CustomerID;
                    Console.WriteLine(p_CustomerID);
                    _newOrder.CustomerID = p_CustomerID;
                    Console.WriteLine("Customer ID saved");
                }
                }
                catch(NullReferenceException)
                {
                    Console.WriteLine("Nothing Found Try Again");
                }
                Console.WriteLine("Press Enter");
                Console.ReadLine();
                return "AddNewOrdersMenu";



                case "2":
                Console.WriteLine("*******************************************************************************");
                Console.WriteLine("*        Retro Barbarian Gaming Lair Has (3) Locations to Serve You           *");
                Console.WriteLine("*******************************************************************************");
                Console.WriteLine("*               Please Enter a Store Front Number (1-3)                       *");
                Console.WriteLine("*You will Need a Product Name, Company, StoreID and Quantity to Order products*");
                Console.WriteLine("*******************************************************************************");
                Console.WriteLine("*                      Press Enter When Ready                                 *");
                Console.WriteLine("*******************************************************************************");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("*******************************************************************");
                Console.WriteLine("***** Enter a Category To See Inventory - Games - or - Systems ****");
                Console.WriteLine("*******************************************************************");
                Console.WriteLine("*       [1] = Games      [2] = Systems    [3] = Merchandise       *");
                Console.WriteLine("*******************************************************************");
                string userinput = Console.ReadLine();
                Console.Clear();
                    switch(userinput)
                    {
                        case "1":
                        string answer1 = "Game";
                        List<Products> listofprod1 = _productBL.SearchProductsCat(answer1);
                            foreach (var Products in listofprod1)
                            {
                                Console.WriteLine("***********************");
                                Console.WriteLine(Products);
                                Console.WriteLine("***********************");
                            }
                            Console.WriteLine("Press Enter to Continue");
                            Console.ReadLine();
                        return "AddNewOrdersMenu";
                        case "2":
                        string answer2 = "System";
                        List<Products> listofprod2 = _productBL.SearchProductsCat(answer2);
                            foreach (var Products in listofprod2)
                            {
                                Console.WriteLine("***********************");
                                Console.WriteLine(Products);
                                Console.WriteLine("***********************");
                            }
                            Console.WriteLine("Press Enter to Continue");
                            Console.ReadLine();
                        return "AddNewOrdersMenu";
                        case "3":
                        string answer3 = "Merchandise";
                        List<Products> listofprod3 = _productBL.SearchProductsCat(answer3);
                            foreach (var Products in listofprod3)
                            {
                                Console.WriteLine("***********************");
                                Console.WriteLine(Products);
                                Console.WriteLine("***********************");
                            }
                            Console.WriteLine("Press Enter to Continue");
                            Console.ReadLine();
                        return "AddNewOrdersMenu";                    
                        default:
                        Console.WriteLine("Choose [1] or [2]");
                        return "AddNewOrdersMenu";
                    }
   

                case "3":
                Console.Clear();
                Console.WriteLine("*******************************************************************************");
                Console.WriteLine("*               Retro Barbarian Gaming Lair Order Screen                      *");
                Console.WriteLine("*******************************************************************************");
                Console.WriteLine("* Store #  - " + _newOrder.StoreID);
                Console.WriteLine("* Name     - " + _newLineItem.ProductName);
                Console.WriteLine("* Company  - " + p_Company);
                Console.WriteLine("* StoreID  - " + _newOrder.StoreID);
                Console.WriteLine("* Quantity - " + _newLineItem.ProductQuantity);
                Console.WriteLine("*******************************************************************************");
                Console.WriteLine("* Please Enter Order Information                                              *");
                Console.WriteLine("*******************************************************************************");
                Console.ReadLine();
                








                return "AddNewOrdersMenu";



                case "4":
                return "AddNewOrdersMenu";



                case "5":
                return "AddNewOrdersMenu";



                case "6":
                _orderBL.AddOrders(_newOrder);
                return "AddNewOrdersMenu";



                default:
                return "AddNewOrdersMenu";
            }
        }
    }
}