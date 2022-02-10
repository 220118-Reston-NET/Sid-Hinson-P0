using StoreModel;
using StoreBL;
namespace StoreUI
{
    public class AddNewOrderMenu : IMenu
    {
        private static List<LineItems> _shoppingCart = new List<LineItems>();
        private static LineItems CartItem = new LineItems();
        private static Orders _shoppingOrder = new Orders();
        private static string p_Email;
        private static int _productID;
        private static double _productPrice;
        public static int _productStoreID;
        private static string _productName;
        private static string _productCompany;
        private static int _productQuantity;
        private static string _orderID;
        public static double OrderTotal;

        //Dependency Injection
        private IProductsBL _productBL;
        private IOrdersBL _orderBL;
        private ICustomersBL _customerBL;
        private IInventoryBL _inv;
        public AddNewOrderMenu(IOrdersBL p_orderBL, IProductsBL p_productBl, ICustomersBL p_customerBL, IInventoryBL p_inv)
        {
            _orderBL = p_orderBL;
            _productBL = p_productBl;
            _customerBL = p_customerBL;
            _inv = p_inv;
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
                    _productStoreID = Convert.ToInt32(Console.ReadLine());
                    return "AddNewOrderMenu";


                // Get Product Name
                case "2":
                    Log.Information("User is entering the Product Name");
                    Console.Clear();
                    _orderBL.DisplayGraphic();
                    Console.WriteLine("Enter a Product Name : ");
                    _productName = Console.ReadLine();
                    _productName = _productName.ToUpper();
                    return "AddNewOrderMenu";


                //Get Product Company
                case "3":
                    Log.Information("User is entering the Product Company");
                    Console.Clear();
                    _orderBL.DisplayGraphic();
                    Console.WriteLine("Enter a Product Company :");
                    _productCompany = Console.ReadLine();
                    _productCompany = _productCompany.ToUpper();
                    return "AddNewOrderMenu";



                //Get Product Quantity
                case "4":
                    Log.Information("User is entering the Product Quantity");
                    Console.Clear();
                    _orderBL.DisplayGraphic();
                    Console.WriteLine("Enter an Product Quantity : ");
                    _productQuantity = Convert.ToInt32(Console.ReadLine());
                    return "AddNewOrderMenu";



                //Add Item to Cart
                case "5":
                    Log.Information("User is adding the Item to the Static Cart");
                    Console.Clear();
                    _orderBL.DisplayGraphic();
                    //Getting Values For Line Item
                    _productID = _productBL.GetID(_productName, _productCompany, _productStoreID);
                    _productPrice = _productBL.GetPrice(_productName, _productCompany, _productStoreID);
                    //Building Line Item
                    CartItem = _orderBL.AddItemFields(_productID, _productQuantity,_productStoreID, _productPrice);
                    //Running Total
                    OrderTotal += _productPrice;
                    
                    //Validate Inventory Level
                    Inventory parlevel = new Inventory();
                    parlevel =_inv.FindItem(_productStoreID, _productID);
                    parlevel.ProductQuantity -= _productQuantity;

                    if(parlevel.ProductQuantity >= 0)
                    {
                        //Add Item to Shopping Cart
                        _shoppingCart.Add(CartItem);
                        Console.WriteLine("This Item was Added to cart.");
                        Console.WriteLine(CartItem);
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("We are sorry, but your we cannot fulfill your order. We must restock.");
                        Console.ReadLine();
                    }
                    return "AddNewOrderMenu";



                // Clear Items from cart
                case "6":
                    Log.Information("User is clearing ALL Items in the Static Cart");
                    Console.Clear();
                    _orderBL.DisplayGraphic();
                    _shoppingCart.Clear();
                    OrderTotal = 0;
                    Console.WriteLine("Your Cart is Empty! Press Enter to Continue");
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



                //**Save to DB Repo
                case "8":

                try
                 {
                    Log.Information("User is attempting to Save their Order to the DB");
                    Console.Clear();
                    _orderBL.DisplayGraphic();

                    //Get Inputs From User - these are parameterized to get the ID
                    Console.WriteLine("To Process Each Order, Please Input Your Email and Password");
                    Log.Information("User is inputting their email address");                   
                    Console.WriteLine("Enter Your User Email");
                    string userEmail = Console.ReadLine();
                    
                    Log.Information("User is inputting their email password");
                    Console.WriteLine("Enter Your User Password");
                    string userPass = Console.ReadLine();

                
                    //**Create Shopping Order To Send to REPO**
                    //Get CustomerID
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
                    _shoppingOrder.OrderStatus = "PROCESSING";

                    //Add Order to Repo
                    Console.WriteLine("Attempting to Add Order ........");
                    _orderBL.AddOrders(_shoppingOrder); 
                    Console.WriteLine("Order Added. Press Enter");



                    //Find the OrderID
                    List<Orders> getcount = new List<Orders>();
                    getcount = _orderBL.GetAllOrders();
                    int OrderID = getcount.Count();
                    
                    //Display Items Ordered
                    Console.WriteLine("These were the Items Ordered");
                    _orderBL.DisplayCart(_shoppingOrder.OrderLineItems);
                    Console.WriteLine("Press Enter to Continue");
                    Console.ReadLine();


                    //Add Order ID to ALL LineItems
                    foreach(LineItems item in _shoppingCart)
                    {
                        item.OrderID = OrderID;
                    }

                    //Add All LineItems to Repo
                    foreach(LineItems item in _shoppingCart)
                    {
                        _orderBL.AddLineItems(item);
                    }
     
                    
                    //Update Inventory
                    //Set IDs, Pull Inventory Item Info, subtract quantity, reupdate Item totals in DB
                    //Throws exceptions when needed
                    foreach(LineItems item in _shoppingCart)
                    {
                    //New Inventory object every loop
                    Inventory inventoryobj1 = new Inventory();
                    //Populating Fields
                    item.StoreID = inventoryobj1.StoreID;
                    item.ProductID = inventoryobj1.ProductID;
                    //Calculate Quantity to subtract in a Variable
                    int subtractvalue = item.ProductQuantity;
                    //Second Inventory object to hold the actual Row Record We Need to Manipulate
                    Inventory inventoryobj2 = new Inventory();
                    inventoryobj2 = _inv.FindItem(inventoryobj1.StoreID, inventoryobj1.ProductID);
                    //Subtract the Value From the Quantity
                    inventoryobj2.ProductQuantity -= subtractvalue;
                        if(inventoryobj2.ProductQuantity < 0)
                        {
                            Console.WriteLine($"We cannot fulfill your order. We are missing {inventoryobj2.ProductQuantity} units ");
                            Console.WriteLine("Press Enter to Continue");
                            Console.ReadLine();
                        }
                        else
                        {
                            _inv.UpdateInventory(inventoryobj2);
                        }
                    }
                }
                catch(InvalidDataException)
                {
                    Console.WriteLine("The Data could not be processed.");
                    Console.WriteLine("Please Look at your Order Input Data and Try Again.");
                }
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