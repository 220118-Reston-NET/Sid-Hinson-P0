using StoreModel;
using StoreBL;
namespace StoreUI
{
    public class NewCustomerOrderMenu : IMenu
    {
        //Static Class for variable Consistently Across the Created Class Objects
        private static LineItems p_LineCart = new LineItems();
        private static Orders p_NewOrder = new Orders();
        private static string p_fname;
        private static string p_lname;
        private static string p_email;
        private static string p_pass;
        //Dependency Injection
        private IProductsBL _productBL;
        private IOrdersBL _orderBL;
        private ICustomersBL _customerBL;
        public NewCustomerOrderMenu(IOrdersBL p_orderBL, IProductsBL p_productBl, ICustomersBL p_customerBL)
        {
            _orderBL = p_orderBL;
            _productBL = p_productBl;
            _customerBL = p_customerBL;
        }
        public void MenuDisplay()
        {
            Console.Clear();
            Console.WriteLine("=========================================================="); 
            Console.WriteLine(")xxxxx[;;;;;;;;;>    )xxxxx[;;;;;;;;;>   )xxxxx[;;;;;;;;;>"); 
            Console.WriteLine("==========================================================");
            Console.WriteLine("==========================================================");
            Console.WriteLine("=                  Menu : Add Customer                   =");
            Console.WriteLine("==========================================================");
            Console.WriteLine("=              Enter New Order Info : Select             =");     
            Console.WriteLine("==========================================================");
            Console.WriteLine("=[0] Return to Main Menu"); 
            Console.WriteLine("=[1] Store # - " + p_NewOrder.OrderStoreID);
            Console.WriteLine("=[2] Product Name - " + p_LineCart.ProductName);
            Console.WriteLine("=[3] Product Company - " + p_LineCart.ProductCompany);
            Console.WriteLine("=[4] Quantity - " + p_LineCart.ProductQuantity);  
            Console.WriteLine("=[5] Update Order Cart With Current Product");
            Console.WriteLine("=[6] Display your Current Cart Details");
            Console.WriteLine("=[7] Reset Current Product Details");
            Console.WriteLine("=[8] Remove All Products From Current Cart");
            Console.WriteLine("=[9] Save & Finish Cart & Checkout for the Entire Order");
            Console.WriteLine("==========================================================");
        }
        
        public string UserSelection()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    return "StoreMainMenu";




                case "1":
                /// *************************** Pull Product ID and Product Price to get here, with StoreID and other info.
                    Console.WriteLine("Enter a Store ID :");
                    p_NewOrder.OrderStoreID = Convert .ToInt32(Console.ReadLine());
                    p_LineCart.StoreID = p_NewOrder.OrderStoreID;
                    return "NewCustomerOrderMenu";




                case "2":
                    Console.WriteLine("Enter a Product Name : ");
                    p_LineCart.ProductName = Console.ReadLine();
                    return "NewCustomerOrderMenu";




                case "3":
                    Console.WriteLine("Enter a Product Company :");
                    p_LineCart.ProductCompany = Console.ReadLine();
                    return "NewCustomerOrderMenu";




                case "4":
                    Console.WriteLine("Enter an Product Quantity : ");
                    p_LineCart.ProductQuantity = Convert.ToInt32(Console.ReadLine());
                    return "NewCustomerOrderMenu";




                case "5":
                    try
                    {   p_NewOrder.OrderLineItems = new List<LineItems>();
                        p_NewOrder.OrderLineItems.Add(p_LineCart);
                        foreach (LineItems i in p_NewOrder.OrderLineItems)
                        {
                            Console.WriteLine(i);
                        }
                        Console.WriteLine("This Product and Quantity Were Added to Cart");
                        Console.WriteLine("Press Enter to Continue");
                        Console.ReadLine();

                    }
                    catch (System.Exception exc)
                    {
                        Console.WriteLine(exc.Message);
                        Console.WriteLine("Something Unexpected Happened");
                        Console.WriteLine("Press Enter to Continue");
                        Console.ReadLine();
                    }
                    return "NewCustomerOrderMenu";



                //**********Fix/Find WorkAround (Add to new List?)Static method Changes Value in the OrderLineItems Problem
                case "6":
                Console.WriteLine("================="); 
                Console.WriteLine(")xxxxx[;;;;;;;;;>"); 
                Console.WriteLine("=================");
                Console.WriteLine("YOUR CURRENT CART:");
                foreach (LineItems i in p_NewOrder.OrderLineItems)
                {
                        Console.WriteLine(i);
                }
                Console.WriteLine("================="); 
                Console.WriteLine(")xxxxx[;;;;;;;;;>"); 
                Console.WriteLine("=================");
                Console.WriteLine("Press Enter to Continue");
                Console.ReadLine();       
                return "NewCustomerOrderMenu";



            
                case "7":
                p_LineCart.ProductName ="No Value";
                p_LineCart.ProductCompany ="No Value";
                p_LineCart.ProductQuantity = 0;
                p_NewOrder.OrderStoreID = 0;
                Console.WriteLine("Something Unexpected Happened");
                Console.WriteLine("Press Enter to Continue");
                Console.ReadLine();
                return "NewCustomerOrderMenu";

  

                /// ************ 7,8 Effectively kinda do the same thing because of Static Properties - Locate Work Around
   


                case "8":
                p_NewOrder.OrderLineItems.Clear();
                return "NewCustomerOrderMenu";



                /// ********** Must Add in Calcualtions to subtract Quantity, Validate from stock, and rewrite everything to repos
                case "9":
                Console.Clear();
                Console.WriteLine("=========================================================="); 
                Console.WriteLine("=        Retro Barbarian Order System Login Screen       =");
                Console.WriteLine("==========================================================");
                Console.WriteLine("=   To Place ALL Orders, System Validation is Required    ="); 
                Console.WriteLine("=========================================================="); 
                Console.WriteLine(")xxxxx[;;;;;;;;;>    )xxxxx[;;;;;;;;;>   )xxxxx[;;;;;;;;;>"); 
                Console.WriteLine("==========================================================");
                Console.WriteLine("Please Enter Your First Name........");
                p_fname = Console.ReadLine();
                Console.WriteLine("Please Enter Your Last Name.........");
                p_lname = Console.ReadLine();
                Console.WriteLine("Please Enter Your Email Address.....");
                p_email = Console.ReadLine();
                Console.WriteLine("Please Enter Your Password..........");
                p_pass = Console.ReadLine();
                Console.WriteLine("Thank you....Please Wait............");
                Console.WriteLine("==========================================================");

                /// <summary>
                /// Customer Authentication and Grabbing Values
                /// </summary>
                /// <returns>listofcustomers,values</returns>
                if(p_fname != "" & p_lname != "" & p_email != "" & p_pass != "")
                {
                List<Customers> listofcustomers = _customerBL.SearchCustomers(p_fname, p_lname, p_email, p_pass);
                List<Customers> listofselected = new List<Customers>();
                for (int i = 0; i < listofcustomers.Count(); i++)
                {
                    if (listofselected[i].CPassword.Contains(p_pass) & listofselected[i].CustomerEmail.Contains(p_email))
                    {
                        listofselected.Add(listofcustomers[i]);
                        p_NewOrder.OrderCustID = listofselected[i].CustomerID;
                        DateTime localDate = DateTime.Now;
                        localDate.ToString(p_NewOrder.OrderDate);
                        /// Adds to Order and Order History Repositories
                        _orderBL.AddOrdersHistory(p_NewOrder);
                        _orderBL.AddOrders(p_NewOrder);
                        Console.WriteLine("=========================================================="); 
                        Console.WriteLine(")xxxxx[;;;;;;;;;>    )xxxxx[;;;;;;;;;>   )xxxxx[;;;;;;;;;>"); 
                        Console.WriteLine("==========================================================");

                    }
                    else
                    {   
                        Console.WriteLine("You Must Enter Valid Information");
            
                    }
                }

                return "NewCustomerOrderMenu";
                }
                else
                {
                Console.WriteLine("Please Try Again");
                Console.WriteLine("Press Enter to Continue");
                Console.ReadLine();
                return "NewCustomerOrderMenu";
                }

                default:
                return "NewCustomerOrderMenu";
            }
        }
    }
}