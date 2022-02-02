using StoreModel;
using StoreBL;
namespace StoreUI
{
    public class AddNewOrdersMenu : IMenu
    {
        //Variables, Collections to Store Information for BL,DL processing
        public static LineItems p_LineToOrder = new LineItems();
        private static Orders p_NewOrder = new Orders();
        private static List<Customers> p_ListofCustomers = new List<Customers>();
        public static string CustomerID;
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
            Console.WriteLine("=[1] - Enter Name & Pass For Shopping          =");
            Console.WriteLine("=[2] - Display Product By Category             =");  
            Console.WriteLine("=[3] - Add Product to Order                    =");
            Console.WriteLine("=[4] - Display Current Order                   =");
            Console.WriteLine("=[5] - Remove Products From Order              =");
            Console.WriteLine("=[6] - Remove ALL Products From Order          =");
            Console.WriteLine("=[7] - Save Customer Order                     =");
            Console.WriteLine("================================================");
        }

        public string UserSelection()
        {
            string userInput = Console.ReadLine();

            //**********************************WORK IN PROGRESS*******************************
            //*********todo:Convert some Switch Statements into BL void/return Methods*********
            //*************Code here is to just get the program to a working state*************
            //*********************************************************************************

            switch (userInput)
            {
                //Return to Main Menu
                case "0":
                return "StoreMainMenu";


                //Registration
                case "1":
                Console.Clear();
                Console.WriteLine("================================================");
                Console.WriteLine("=    Retro Barbarian Gaming Lair Shop Menu     =");
                Console.WriteLine("================================================");
                Console.WriteLine("Please Enter a First Name");
                string p_fname = Console.ReadLine();
                Console.WriteLine("Please Enter a Last Name");
                string p_lname = Console.ReadLine();
                Console.WriteLine("Enter Customer Email Address");
                p_NewOrder.OrdCustEmail = Console.ReadLine();
                Console.WriteLine("Thank you for Registering! Now you can save ORDERS.");
                Console.WriteLine("================================================");
                List<Customers> listofcustomers = _customerBL.SearchCustomers(p_fname, p_lname, p_NewOrder.OrdCustEmail);
                p_ListofCustomers = listofcustomers;
                try
                {          
                foreach (var Customer in listofcustomers)
                {
                    p_NewOrder.OrdCustID = Customer.CustomerID;
                    Console.WriteLine(Customer);
                }
                }
                catch(NullReferenceException)
                {
                    Console.WriteLine("Nothing Found Try Again");
                }
                Console.WriteLine("Press Enter");
                Console.ReadLine();
                return "AddNewOrdersMenu";


                //Choose Product Category
                case "2":
                Console.Clear();
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
   
                //Order Creation
                case "3":
                Console.Clear();
                Console.WriteLine("*******************************************************************************");
                Console.WriteLine("*               Retro Barbarian Gaming Lair Order Screen                      *");
                Console.WriteLine("*******************************************************************************");
                Console.WriteLine("* CustomerID - " + p_NewOrder.OrdCustID);
                Console.WriteLine("* Store # - " + p_NewOrder.OrdStoreID);
                Console.WriteLine("* Product Name - " + p_LineToOrder.ProductName);
                Console.WriteLine("* Quantity - " + p_LineToOrder.ProductQuantity);
                Console.WriteLine("* Company - " + p_LineToOrder.ProdCompany);                
                Console.WriteLine("* Customer Email - " + p_NewOrder.OrdCustEmail);
                Console.WriteLine("*******************************************************************************");
                Console.WriteLine("* Please Enter Order Information                                              *");
                Console.WriteLine("*******************************************************************************");
                Console.WriteLine("Enter Store Number:");
                p_NewOrder.OrdStoreID = Console.ReadLine();
                Console.WriteLine("Enter Product Name:");
                p_LineToOrder.ProductName = Console.ReadLine();
                Console.WriteLine("Enter Product Company:");
                p_LineToOrder.ProdCompany = Console.ReadLine();
                Console.WriteLine("Enter Quantity of product:");
                p_LineToOrder.ProductQuantity = Convert.ToInt32(Console.ReadLine());

                //Add LineItem Order to Order List
                p_NewOrder.OrderLineItems.Add(p_LineToOrder);
                Console.WriteLine("*****************************");
                Console.WriteLine("***Press Enter to Continue***");
                Console.WriteLine("*****************************");
                Console.ReadLine();
                return "AddNewOrdersMenu"; 


                //Display Order
                case "4":
                Console.Clear();
                Console.WriteLine("*****************************");
                _orderBL.DisplayOrder(p_NewOrder);
                Console.WriteLine("*****************************");
                Console.WriteLine("***Press Enter to Continue***");
                Console.WriteLine("*****************************");
                Console.ReadLine();
                return "AddNewOrdersMenu";


                // //Remove Product
                case "5":
                Console.Clear();
                // Console.WriteLine("******************************");
                // Console.WriteLine("*******Remove Products********");
                // Console.WriteLine("******************************");
                // Console.WriteLine("Enter Product Name:");
                // string p_ProdName = Console.ReadLine();
                // Console.WriteLine("Enter Product Company:");
                // string p_ProdCompany = Console.ReadLine();

                return "AddNewOrdersMenu";


                //Remove ALL Products
                case "6":
                p_NewOrder.OrderLineItems.Clear();
                Console.WriteLine("*****************************");
                _orderBL.DisplayOrder(p_NewOrder);
                Console.WriteLine("*****************************");
                Console.WriteLine("****All Products Cleared!****");
                Console.WriteLine("*****************************");
                Console.WriteLine("***Press Enter to Continue***");
                Console.WriteLine("*****************************");
                Console.ReadLine();
                return "AddNewOrdersMenu";

                //Save Order
                case "7":
                p_NewOrder.OrderLineItems.Add(p_LineToOrder);
                Console.WriteLine(p_NewOrder.OrderLineItems);
                Console.WriteLine("Added Line Items to Order");
                Console.ReadLine();
                Console.WriteLine("Attempting to Save Order");
                _orderBL.AddOrders(p_NewOrder);
                return "AddNewOrdersMenu";


                //Default Case
                default:
                return "AddNewOrdersMenu";
            }
        }
    }
}