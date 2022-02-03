using StoreModel;
using StoreBL;
namespace StoreUI
{
    public class NewCustomerOrderMenu : IMenu
    {
        //Static Class for variable Consistentcy
        public Orders ShoppingCart = new Orders();
        private static string p_fname;
        private static string p_lname;
        private static string p_email;
        private string p_pass;
        public static int ProductStoreID ;
        public static string ProductName;
        public static string ProductCompany;
        public static int ProductQuantity;

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
            Console.WriteLine("=[1] Store # - " + ProductStoreID);
            Console.WriteLine("=[2] Product Name - " + ProductName);
            Console.WriteLine("=[3] Product Company - " + ProductCompany);
            Console.WriteLine("=[4] Quantity - " + ProductQuantity);  
            Console.WriteLine("=[5] Add Order to Cart");
            Console.WriteLine("=[6] Remove Orders From Cart");
            Console.WriteLine("=[7] Save & Checkout");
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

                    Console.WriteLine("Enter a Store ID :");
                    ProductStoreID = Convert .ToInt32(Console.ReadLine());
                    return "NewCustomerOrderMenu";




                case "2":
                    Console.WriteLine("Enter a Product Name : ");
                    ProductName = Console.ReadLine();
                    return "NewCustomerOrderMenu";




                case "3":
                    Console.WriteLine("Enter a Product Company :");
                    ProductCompany = Console.ReadLine();
                    return "NewCustomerOrderMenu";




                case "4":
                    Console.WriteLine("Enter an Product Quantity : ");
                    ProductQuantity = Convert.ToInt32(Console.ReadLine());
                    return "NewCustomerOrderMenu";




                case "5":
                    return "NewCustomerOrderMenu";




                case "6":
                ShoppingCart.OrderLineItems.Clear();
                return "NewCustomerOrderMenu";




                case "7":
                return "NewCustomerOrderMenu";




                default:
                return "NewCustomerOrderMenu";
            }
        }
    }
}