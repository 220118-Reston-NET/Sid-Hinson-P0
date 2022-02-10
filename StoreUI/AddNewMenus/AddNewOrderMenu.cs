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
                    CartItem = _orderBL.AddItemFields(_productID, _orderID, _productQuantity);
                    CartItem.StoreID = _productStoreID;
                    //Running Total
                    OrderTotal += _productPrice;
                    //Add Item to Shopping Cart
                    _shoppingCart.Add(CartItem);
                    Console.WriteLine("This Item was Added to cart.");
                    Console.WriteLine(CartItem);
                    Console.ReadLine();
                    return "AddNewOrderMenu";



                // Clear Items from cart
                case "6":
                    Log.Information("User is clearing ALL Items in the Static Cart");
                    Console.Clear();
                    _orderBL.DisplayGraphic();
                    _shoppingCart.Clear();
                    OrderTotal = 0;
                    _shoppingOrder.OrderID = "";
                    Console.WriteLine("Your Cart is Empty!");
                    Console.WriteLine("Your Unique Order ID has been reset to void value. Press Enter.");
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
                    _orderBL.DisplayCart(_shoppingOrder.OrderLineItems);
                    Console.WriteLine("Press Enter to Continue");
                    Console.ReadLine();

                    //Add All LineItems to Repo
                    foreach(LineItems item in _shoppingCart)
                    {
                        _orderBL.AddLineItems(item);
                    }
                    //Add Order to Repo
                    _orderBL.AddOrders(_shoppingOrder);      
                    
                    
                    //Update Inventory
                    //Set IDs, Pull Inventory Item Info, subtract quantity, reupdate Item totals in DB
                    //Throws exceptions when needed
                    foreach(LineItems inv_item in _shoppingCart)
                    {
                        try
                        {
                        Inventory inventoryobj = new Inventory();
                        inv_item.StoreID = inventoryobj.StoreID;
                        inv_item.ProductID = inventoryobj.ProductID;
                        int subtractvalue = inv_item.ProductQuantity;
                        inventoryobj = _inv.FindItem(inventoryobj.StoreID, inventoryobj.ProductID);
                        inventoryobj.ProductQuantity -= subtractvalue;
                            if(inventoryobj.ProductQuantity < 0)
                            {
                                Console.WriteLine("I am sorry but the Quantity Specified in one of your Orders, cannot be fulfilled.");
                                throw new ArgumentOutOfRangeException();
                            }
                            else
                            {
                                _inv.UpdateInventory(inventoryobj);
                            }

                        }
                        catch
                        {
                            Console.WriteLine(" One of your Orders Cannot be Fulfilled due to incorrect Data. Please restart your order.");
                            throw new ArgumentException();
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