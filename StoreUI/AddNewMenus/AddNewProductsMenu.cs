using StoreModel;
using StoreBL;
namespace StoreUI
{
    public class AddNewProductsMenu : IMenu
    {
        //Static Class for variable Consistently Across the Created Class Objects
        private static Products _newProduct = new Products();
        //Dependency Injection
        private IProductsBL _productBL;
        //
        public AddNewProductsMenu(IProductsBL p_product)
        {
            _productBL = p_product;
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
            Console.WriteLine("=[7] - Enter Product Quantity: " + _newProduct.ProductSTFQuantity);
            Console.WriteLine("=[8] - Update & Save Information");
            Console.WriteLine("===============================================");
        }

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
                    _newProduct.StoreID = Convert.ToInt32(Console.ReadLine());
                    return "AddNewProductsMenu";


                case "2":
                    Log.Information("User is inputting the Product Name");
                    Console.WriteLine("Enter a Product Name : ");
                    _newProduct.ProductName = Console.ReadLine();
                    return "AddNewProductsMenu";


                case "3":
                    Log.Information("User is inputting the Product Company");
                    Console.WriteLine("Enter a Product Company : ");
                    _newProduct.ProductCompany = Console.ReadLine();
                    return "AddNewProductsMenu";


                case "4":
                    Log.Information("User is inputting the Product Price");
                    Console.WriteLine("Enter a Product Price : ");
                    _newProduct.ProductPrice = Convert.ToDouble(Console.ReadLine());
                    return "AddNewProductsMenu";


                case "5":
                    Log.Information("User is inputting the Product Description");
                    Console.WriteLine("Enter a Product Description : ");
                    _newProduct.ProductDescription = Console.ReadLine();
                    return "AddNewProductsMenu";


                case "6":
                    Log.Information("User is inputting the Product Category");
                    Console.WriteLine("Enter a Product Category : ");
                    _newProduct.ProductCategory = Console.ReadLine();
                    return "AddNewProductsMenu";


                case "7":
                    Log.Information("User is inputting the Product Quantity");
                    Console.WriteLine("Enter a Quantity : ");
                    _newProduct.ProductSTFQuantity = Convert.ToInt32(Console.ReadLine());
                    return "AddNewProductsMenu";

                //*************TODO: Validation check Method on all Inputs 
                //*************TODO: Logic to add to WAREHOUSE INVENTORY DB ---and---- Products DB 
                case "8":
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