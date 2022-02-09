using StoreModel;
using StoreBL;
namespace StoreUI
{
    public class AddNewOrderMenu : IMenu
    {
        private static List<LineItems> _shoppingCart = new List<LineItems>();
        public LineItems Item = new LineItems();
        private static Orders _shoppingOrder = new Orders();
        private static string p_Email;
        private static int _productID;
        private static double _productPrice;
        private static int _productStoreID;
        private static string _productName;
        private static string _productCompany;
        private static int _productQuantity;
        private static string _orderID;
        public static double OrderTotal;

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
            Console.WriteLine("=[1] Store # - " + _productStoreID);
            Console.WriteLine("=[2] Product Name - " + _productName);
            Console.WriteLine("=[3] Product Company - " + _productCompany);
            Console.WriteLine("=[4] Quantity - " + _productQuantity);  
            Console.WriteLine("=[5] Add Order to Cart");
            Console.WriteLine("=[6] Remove Orders From Cart");
            Console.WriteLine("=[7] Display Orders From Cart");
            Console.WriteLine("=[8] Save and Checkout Order");
            Console.WriteLine("==========================================================");
            Console.WriteLine("= * ProductID - " + _productID);
            Console.WriteLine("= * Product Price - " + _productPrice);
            Console.WriteLine("=========================================================="); 
            Console.WriteLine(")xxxxx[;;;;;;;;;>    )xxxxx[;;;;;;;;;>   )xxxxx[;;;;;;;;;>"); 
            Console.WriteLine("==========================================================");

        }
        
        public string UserSelection()
        {
            Log.Information("User is entering their selection");
            string userInput = Console.ReadLine();
            switch (userInput)
            {

                //Return to StoreMenu
                case "0":
                    Log.Information("User is selecting Store Main Menu");
                    return "StoreMainMenu";


                // Get Store Id of Product
                case "1":
                    Log.Information("User is entering the Store ID");
                    Console.Clear();
                    _orderBL.DisplayGraphic();
                    Console.WriteLine("Enter a Store ID :");
                    //Test for Number
                    string test = Console.ReadLine();
                    bool isNumber = false;
                    isNumber = int.TryParse(test, out int x);
                    _productStoreID = x;
                    while(isNumber == false)
                    {
                        Console.WriteLine("You Must Enter A Whole Number Interger. Please Enter Now :");
                        string Retry = Console.ReadLine();
                        isNumber = int.TryParse(Retry, out int result);
                       _productStoreID = result;
                    }
                    return "AddNewOrderMenu";


                // Get Product Name
                case "2":
                    Log.Information("User is entering the Product Name");
                    Console.Clear();
                    _orderBL.DisplayGraphic();
                    Console.WriteLine("Enter a Product Name : ");
                    _productName = Console.ReadLine();
                    //Test for Null or Empty
                    while(string.IsNullOrEmpty(_productName))
                    {
                        Console.WriteLine("Input must have a Product Name. Please Enter a Product Name:");
                       _productName = Console.ReadLine();
                        return "AddNewOrderMenu";
                    }
                    return "AddNewOrderMenu";


                //Get Product Company
                case "3":
                    Log.Information("User is entering the Product Company");
                    Console.Clear();
                    _orderBL.DisplayGraphic();
                    Console.WriteLine("Enter a Product Company :");
                    _productCompany = Console.ReadLine();
                    //Test for Null or Empty
                    while(string.IsNullOrEmpty(_productCompany))
                    {
                        Console.WriteLine("Input must have a Product Company. Please Enter a Product Company:");
                      _productCompany = Console.ReadLine();
                        return "AddNewOrderMenu";
                    }
                    return "AddNewOrderMenu";



                //Get Product Quantity
                case "4":
                    Log.Information("User is entering the Product Quantity");
                    Console.Clear();
                    _orderBL.DisplayGraphic();
                    Console.WriteLine("Enter an Product Quantity : ");
                    //Test for Number
                    string test2 = Console.ReadLine();
                    bool isANumber = false;
                    isANumber = int.TryParse(test2, out int y);
                    _productQuantity = y;
                    while(isANumber == false)
                    {
                        Console.WriteLine("You Must Enter A Whole Number Interger. Please Enter Now :");
                        string Retry = Console.ReadLine();
                        isANumber = int.TryParse(Retry, out int result);
                       _productQuantity  = result;
                    }
                    return "AddNewOrderMenu";



                //Add Item to Cart
                case "5":
                    Log.Information("User is adding the Item to the Static Cart");
                    Console.Clear();
                    _orderBL.DisplayGraphic();
                    //Generate Unique ID for Lineitem/Order
                    //This was opted for global uniqueness and security
                    _orderID = System.Guid.NewGuid().ToString();
                    Item.OrderID = _orderID;
                    _shoppingOrder.OrderID = _orderID;
                    //Add Values to Line Item
                    _productID = _productBL.GetID(_productName, _productCompany, _productStoreID);
                    _productPrice = _productBL.GetPrice(_productName, _productCompany, _productStoreID);
                    OrderTotal += _productPrice;
                    Item = _orderBL.AddItem(_productID, _orderID, _productQuantity);
                    //Add Item to Cart
                    _shoppingCart.Add(Item);
                    Console.WriteLine("Item was Added to cart.");
                    Console.WriteLine("Press Enter to Continue");
                    Console.ReadLine();
                    return "AddNewOrderMenu";



                // Clear Items from cart
                case "6":
                    Log.Information("User is clearing Items in the Static Cart");
                    Console.Clear();
                    _orderBL.DisplayGraphic();
                    _shoppingCart.Clear();
                    OrderTotal = 0;
                    Console.WriteLine("Cart is Empty! Press Enter to Continue");
                    Console.ReadLine();
                    return "AddNewOrderMenu";



                //Display ShoppingCart
                case "7":
                    Log.Information("User is displaying Items in the Static Cart");
                    Console.Clear();
                    _orderBL.DisplayGraphic();
                    _orderBL.DisplayCart(_shoppingCart);
                    Console.WriteLine($"Current Order Total = ${OrderTotal}");
                    Console.WriteLine("Press Enter to Continue");
                    Console.ReadLine();
                    return "AddNewOrderMenu";



                //**Save and Checkout Process
                case "8":
                    Log.Information("User is attempting to Save their Order to the DB");
                    Console.Clear();
                    _orderBL.DisplayGraphic();

                    //Get Inputs
                    Console.WriteLine("To Process Each Order, Please Input Your Email and Password");
                    Log.Information("User is inputting their email address");                   
                    Console.WriteLine("Enter Your User Email");
                    string userEmail = Console.ReadLine();
                    
                    Log.Information("User is inputting their email password");
                    Console.WriteLine("Enter Your User Password");
                    string userPass = Console.ReadLine();

                    //**Create Shopping Order To Send to REPO**
                    //Adding CustomerID
                    _shoppingOrder.OrderCustID = _customerBL.GetID(userEmail, userPass);

                    //Adding StoreID
                    _shoppingOrder.OrderStoreID = _productStoreID;
                    //Adding Date Time of Order
                    DateTime OrderDate = DateTime.Now;
                    _shoppingOrder.OrderDate = OrderDate.ToString("MM/dd/yyyy");
                    //Adding Order Total
                    _shoppingOrder.OrderTotal = OrderTotal;
                    //Adding Line Items Cart to Order
                    _shoppingOrder.OrderLineItems = new List<LineItems>();
                    _shoppingOrder.OrderLineItems = _shoppingCart;
                    _shoppingOrder.OrderStatus = "Processing";
                    //*************TODO: Validation check Method on all Inputs and TRY/CATCH 
                    //*************TODO: Inventory Logic that subtracts from WAREHOUSE Inventory DB ---and--- Store Product Inventory
                    _orderBL.DisplayCart(_shoppingOrder.OrderLineItems);
                    Console.WriteLine("Press Enter to Continue");
                    Console.ReadLine();

                    //**Processing
                    //Add All LineItems to Repo
                    foreach(LineItems item in _shoppingCart)
                    {
                        _orderBL.AddLineItems(item);
                    }
                    //Add Order to Repo
                    _orderBL.AddOrders(_shoppingOrder);      
                    return "AddNewOrderMenu";


                //Default Menu
                default:
                Log.Information("User has made an Invalid Selection");
                Console.WriteLine("You have made an Invalid Selection - Please Press Enter to Continue");
                Console.ReadLine();
                return "AddNewOrderMenu";
            }
        }
    }
}