using StoreModel;
using StoreBL;
namespace StoreUI
{
    public class AddNewProductsMenu : IMenu
    {
        //Static Class for variable Consistently Across the Created Class Objects

        private static Inventory _newInventory = new Inventory();
        private static Products _newProduct = new Products();
        //Dependency Injection
        private IInventoryBL _invBL;
        private IProductsBL _productBL;
        //
        public AddNewProductsMenu(IProductsBL p_product, IInventoryBL p_inv)
        {
            _productBL = p_product;
            _invBL = p_inv;
        }
        public void MenuDisplay()
        {
            Console.Clear();
            Console.WriteLine("================================================");
            Console.WriteLine("=             Menu : Add Product               =");
            Console.WriteLine("================================================");
            Console.WriteLine("=       Enter New Product Info : Select        =");     
            Console.WriteLine("================================================");
            Console.WriteLine("=[0] - Return to Main Menu");
            Console.WriteLine("=[1] - Enter Store Number: " + _newProduct.StoreID);
            Console.WriteLine("=[2] - Enter Product Name: " + _newProduct.ProductName);
            Console.WriteLine("=[3] - Enter Product Company: " + _newProduct.ProductCompany);
            Console.WriteLine("=[4] - Enter Product Price: " + _newProduct.ProductPrice); 
            Console.WriteLine("=[5] - Enter Product Description: " + _newProduct.ProductDescription);
            Console.WriteLine("=[6] - Enter Product Category: " + _newProduct.ProductCategory);
            Console.WriteLine("=[7] - Enter Product Quantity: " + _newInventory.ProductQuantity);
            Console.WriteLine("=[8] - Update & Save Information");
            Console.WriteLine("===============================================");
        }

        //***TODO:VALIDATION ON ALL INPUTS
        public string UserSelection()
        {
            Log.Information("User is inputting the Menu Selection");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    Log.Information("User is selecting Store Main Menu");
                    return "StoreMainMenu";


                case "1":
                    Log.Information("User is inputting the Store Number");
                    Console.WriteLine("Enter a Store Number :");
                    string Test = Console.ReadLine();
                    //Testing for an Integer Value
                    bool isNumber = false;
                    isNumber = int.TryParse(Test, out int i);
                    _newProduct.StoreID = i;
                    while(isNumber == false || _newProduct.StoreID < 0)
                    {
                        Console.WriteLine("You Must Enter a Numerical, Postive Whole Number for Store ID");
                        string Retry = Console.ReadLine();
                        isNumber = int.TryParse(Retry, out int result);
                        _newProduct.StoreID = result;
                    }   
                    return "AddNewProductsMenu";


                case "2":
                    Log.Information("User is inputting the Product Name");
                    Console.WriteLine("Enter a Product Name : ");
                    _newProduct.ProductName = Console.ReadLine();
                    _newProduct.ProductName = _newProduct.ProductName.ToUpper();
                    while(string.IsNullOrEmpty(_newProduct.ProductName))
                    {
                        Console.WriteLine("Selected Information must have an input. Please Re-enter now :");
                        _newProduct.ProductName = Console.ReadLine();
                        _newProduct.ProductName = _newProduct.ProductName.ToUpper();
                    }
                    return "AddNewProductsMenu";


                case "3":
                    Log.Information("User is inputting the Product Company");
                    Console.WriteLine("Enter a Product Company : ");
                    _newProduct.ProductCompany = Console.ReadLine();
                    _newProduct.ProductCompany = _newProduct.ProductCompany.ToUpper();
                    while(string.IsNullOrEmpty(_newProduct.ProductCompany))
                    {
                        Console.WriteLine("Selected Information must have an input. Please Re-enter Now :");
                        _newProduct.ProductCompany =Console.ReadLine();
                        _newProduct.ProductCompany = _newProduct.ProductCompany.ToUpper();
                    }
                    return "AddNewProductsMenu";


                case "4":
                    Log.Information("User is inputting the Product Price");
                    Console.WriteLine("Enter a Product Price : ");
                    string Test2 = Console.ReadLine();
                    //Testing for an Integer Value
                    bool isNumber2 = false;
                    isNumber = int.TryParse(Test2, out int y);
                    _newProduct.ProductPrice = y;
                    while(isNumber2 == false ||  _newProduct.ProductPrice < 0)
                    {
                        Console.WriteLine("You Must Enter a Numerical, Postive Value For Price. Please re-enter Now:");
                        string Retry = Console.ReadLine();
                        isNumber2 = int.TryParse(Retry, out int result);
                        _newProduct.ProductPrice = result;
                    }  
                    return "AddNewProductsMenu";


                case "5":
                    Log.Information("User is inputting the Product Description");
                    Console.WriteLine("Enter a Product Description : ");
                    _newProduct.ProductDescription = Console.ReadLine();
                    _newProduct.ProductDescription = _newProduct.ProductDescription.ToUpper();
                    //Test for Null/Empty
                    while(string.IsNullOrEmpty(_newProduct.ProductDescription))
                    {
                        Console.WriteLine("Selected Information must have an input. Please Re-enter now :");
                        _newProduct.ProductDescription =Console.ReadLine();
                        _newProduct.ProductDescription = _newProduct.ProductDescription.ToUpper();
                    }
                    return "AddNewProductsMenu";


                case "6":
                    Log.Information("User is inputting the Product Category");
                    Console.WriteLine("Enter a Product Category : ");
                    _newProduct.ProductCategory = Console.ReadLine();
                    _newProduct.ProductCategory = _newProduct.ProductCategory.ToUpper();
                    //Test for Null/Empty
                    while(string.IsNullOrEmpty(_newProduct.ProductCategory))
                    {
                        Console.WriteLine("Selected Information must have an input. Please Re-enter now :");
                        _newProduct.ProductCategory =Console.ReadLine();
                        _newProduct.ProductCategory = _newProduct.ProductCategory.ToUpper();
                    }
                    return "AddNewProductsMenu";


                case "7":
                    Log.Information("User is inputting the Product Quantity");
                    Console.WriteLine("Enter a Quantity : ");
                    bool isNumber3 = false;
                    string Test3 = Console.ReadLine();
                    isNumber3 = int.TryParse(Test3, out int x);
                    _newInventory.ProductQuantity = x;
                    do
                    {
                        Console.WriteLine("Selected Information must have a Postive, Numerical input. Please Re-enter now :");
                        string Retry = Console.ReadLine();
                        isNumber3 = int.TryParse(Retry, out int result);
                        _newInventory.ProductQuantity = result;

                    }
                    while(isNumber3 == false || _newInventory.ProductQuantity < 0);
                    return "AddNewProductsMenu";


                //*************TODO: Validation check Method on all Inputs, CHECK FOR NULLS/EMPTY BEFORE ADD
                case "8":
                    //Add Product to DB
                    Log.Information("User is attempting to Save the Product to the DB");
                    try
                    {   
                        _productBL.AddProducts(_newProduct);

                    }
                    catch (System.Exception exc)
                    {
                        Console.WriteLine(exc.Message);
                        Console.WriteLine("Something Unexpected Happened");
                        Console.WriteLine("Press Enter to Continue");
                        Console.ReadLine();
                    }
                    //Add Product Information to Inventory
                    List<Products> getlastindex = new List<Products>();
                    getlastindex = _productBL.GetAllProducts();
                    int ProductID = getlastindex.Count() - 1 ;
                    _newInventory.StoreID = _newProduct.StoreID;
                    _newInventory.ProductID = ProductID;
                    try
                    {   
                        _invBL.AddInventory(_newInventory);

                    }
                    catch (System.Exception exc)
                    {
                        Console.WriteLine(exc.Message);
                        Console.WriteLine("Something Unexpected Happened");
                        Console.WriteLine("Press Enter to Continue");
                        Console.ReadLine();
                    }
                    return "AddNewProductsMenu";


                    default:
                    Log.Information("User has made an Invalid Selection");
                    Console.WriteLine("You have made an Invalid Selection - Please Press Enter to Continue");
                    Console.ReadLine();
                    return "AddNewProductsMenu";
            }
        }
    }
}