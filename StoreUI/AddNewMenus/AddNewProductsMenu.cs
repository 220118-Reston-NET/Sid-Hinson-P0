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
            Console.WriteLine("=[1] - Enter Store Number: " + _newProduct.storeNumber);
            Console.WriteLine("=[2] - Enter Product Name: " + _newProduct.productName);
            Console.WriteLine("=[3] - Enter Product Company: " + _newProduct.productCompany);
            Console.WriteLine("=[4] - Enter Product Price: " + _newProduct.productPrice); 
            Console.WriteLine("=[5] - Enter Product Description: " + _newProduct.productDescription);
            Console.WriteLine("=[6] - Enter Product Category: " + _newProduct.productCategory);
            Console.WriteLine("=[7] - Enter Product Quantity: " + _newProduct.productQuantity);
            Console.WriteLine("=[8] - Update & Save Information");
            Console.WriteLine("===============================================");
        }

        public string UserSelection()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    return "MainMenu";
                case "1":
                    Console.WriteLine("Enter a Store Number :");
                    _newProduct.storeNumber = Convert.ToInt32(Console.ReadLine());
                    return "AddNewProductsMenu";
                case "2":
                    Console.WriteLine("Enter a Product Name : ");
                    _newProduct.productName = Console.ReadLine();
                    return "AddNewProductsMenu";
                case "3":
                    Console.WriteLine("Enter a Product Company : ");
                    _newProduct.productCompany = Console.ReadLine();
                    return "AddNewProductsMenu";
                case "4":
                    Console.WriteLine("Enter a Product Price : ");
                    _newProduct.productPrice = Convert.ToDouble(Console.ReadLine());
                    return "AddNewProductsMenu";
                case "5":
                    Console.WriteLine("Enter a Product Description : ");
                    _newProduct.productDescription = Console.ReadLine();
                    return "AddNewProductsMenu";
                case "6":
                    Console.WriteLine("Enter a Product Category : ");
                    _newProduct.productCategory = Console.ReadLine();
                    return "AddNewProductsMenu";
                case "7":
                    Console.WriteLine("Enter a Quantity : ");
                    _newProduct.productQuantity = Convert.ToInt32(Console.ReadLine());
                    return "AddNewProductsMenu";
                case "8":
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
                    return "AddNewProductsMenu";
            }
        }
    }
}