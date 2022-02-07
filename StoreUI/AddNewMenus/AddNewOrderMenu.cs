using StoreModel;
using StoreBL;
namespace StoreUI
{
    public class AddNewOrderMenu : IMenu
    {
        public static List<LineItems> ShoppingCart = new List<LineItems>();
        public LineItems Item = new LineItems();
        public static Orders ShoppingOrder = new Orders();
        public static string p_Email;
        public static int ProductID;
        public static double ProductPrice;
        public static int ProductStoreID;
        public static string ProductName;
        public static string ProductCompany;
        public static int ProductQuantity;

        //Dependency Injection
        private IProductsBL _productBL;
        private IOrdersBL _orderBL;
        private ICustomersBL _customerBL;
        public AddNewOrderMenu(IOrdersBL p_orderBL, IProductsBL p_productBl, ICustomersBL p_customerBL)
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
            Console.WriteLine("=                    Menu : Add Order                    =");
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
            Console.WriteLine("=[7] Display Orders From Cart");
            Console.WriteLine("=[8] Save and Checkout Order");
            Console.WriteLine("==========================================================");
            Console.WriteLine("= * ProductID - " + ProductID);
            Console.WriteLine("= * Product Price - " + ProductPrice);
            Console.WriteLine("=========================================================="); 
            Console.WriteLine(")xxxxx[;;;;;;;;;>    )xxxxx[;;;;;;;;;>   )xxxxx[;;;;;;;;;>"); 
            Console.WriteLine("==========================================================");

        }
        
        public string UserSelection()
        {

            string userInput = Console.ReadLine();
            switch (userInput)
            {

                //Return to StoreMenu
                case "0":
                    return "StoreMainMenu";


                // Get Store Id of Product
                case "1":
                    Console.Clear();
                    _orderBL.DisplayGraphic();
                    Console.WriteLine("Enter a Store ID :");
                    ProductStoreID = Convert.ToInt32(Console.ReadLine());
                    return "AddNewOrderMenu";


                // Get Product Name
                case "2":
                    Console.Clear();
                    _orderBL.DisplayGraphic();
                    Console.WriteLine("Enter a Product Name : ");
                    ProductName = Console.ReadLine();
                    return "AddNewOrderMenu";


                //Get Product Company
                case "3":
                    Console.Clear();
                    _orderBL.DisplayGraphic();
                    Console.WriteLine("Enter a Product Company :");
                    ProductCompany = Console.ReadLine();
                    return "AddNewOrderMenu";



                //Get Product Quantity
                case "4":
                    Console.Clear();
                    _orderBL.DisplayGraphic();
                    Console.WriteLine("Enter an Product Quantity : ");
                    ProductQuantity = Convert.ToInt32(Console.ReadLine());
                    return "AddNewOrderMenu";



                //Add Item to Cart
                case "5":
                    Console.Clear();
                    _orderBL.DisplayGraphic();
                    Item = _orderBL.AddItem(ProductID, ProductStoreID, ProductName, ProductPrice, ProductQuantity);
                    ProductID = _productBL.GetID(ProductName, ProductCompany, ProductStoreID);
                    ProductPrice = _productBL.GetPrice(ProductName, ProductCompany, ProductStoreID);
                    ShoppingCart.Add(Item);
                    Console.WriteLine("Item was Added to cart.");
                    Console.WriteLine("Press Enter to Continue");
                    Console.ReadLine();
                    return "AddNewOrderMenu";



                // Clear Items from cart
                case "6":
                    Console.Clear();
                    _orderBL.DisplayGraphic();
                    ShoppingCart.Clear();
                    Console.WriteLine("Cart is Empty! Press Enter to Continue");
                    Console.ReadLine();
                    return "AddNewOrderMenu";



                //Display ShoppingCart
                case "7":
                    Console.Clear();
                    _orderBL.DisplayGraphic();
                    _orderBL.DisplayCart(ShoppingCart);
                    Console.WriteLine("Press Enter to Continue");
                    Console.ReadLine();
                    return "AddNewOrderMenu";



                // Save and Checkout
                case "8":
                    Console.Clear();
                    _orderBL.DisplayGraphic();
                    Console.WriteLine("To Process Each Order, Please Input Your Email and Password");
                    Console.WriteLine("Enter Your User Email");
                    string userEmail = Console.ReadLine();
                    Console.WriteLine("Enter Your User Password");
                    string userPass = Console.ReadLine();
                    ShoppingOrder.OrderCustID = _customerBL.GetID(userEmail, userPass);
                    DateTime localDate = DateTime.Now;
                    localDate.ToString(ShoppingOrder.OrderDate);
                    ShoppingOrder.OrderLineItems = new List<LineItems>();
                    ShoppingOrder.OrderLineItems = ShoppingCart;
                    _orderBL.DisplayCart(ShoppingOrder.OrderLineItems);
                    Console.WriteLine("Press Enter to Continue");
                    Console.ReadLine();
                    // _orderBL.AddOrders(ShoppingOrder);      
                    return "AddNewOrderMenu";


                //Default Menu
                default:
                return "AddNewOrderMenu";
            }
        }
    }
}