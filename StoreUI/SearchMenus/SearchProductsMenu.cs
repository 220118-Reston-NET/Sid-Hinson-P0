using StoreModel;
using StoreBL;
namespace StoreUI
{
    public class SearchProductsMenu : IMenu
    {
        private IProductsBL _productBL;

        public SearchProductsMenu(IProductsBL p_productBL)
        {
            _productBL = p_productBL; 
        }
        public void MenuDisplay()
        {   
            Console.Clear();
            Console.WriteLine("   =========================================================="); 
            Console.WriteLine("   )xxxxx[;;;;;;;;;>    )xxxxx[;;;;;;;;;>   )xxxxx[;;;;;;;;;>"); 
            Console.WriteLine("   ==========================================================");
            Console.WriteLine("================================================================");
            Console.WriteLine("=          Menu : Search Products                              =");
            Console.WriteLine("================================================================");
            Console.WriteLine("=              Select Option :                                 =");
            Console.WriteLine("= [0] - Exit Search                                            =");
            Console.WriteLine("= [1] - Find Product by Name, Store, and Company               ="); 
            Console.WriteLine("= [2] - Find Product by Specific Category                      =");
            Console.WriteLine("= [3] - Find Product by Company                                =");
            Console.WriteLine("================================================================");
        }

        public string UserSelection()
        {
            string UserInput = Console.ReadLine();
            while(string.IsNullOrEmpty(UserInput))
            {
                Console.WriteLine("Selection must have an input. Please Enter a Menu selection.");
                UserInput =Console.ReadLine();

            }
            switch (UserInput)
            {
                case "0":
                    return "StoreMainMenu";


                case "1":
                    Console.WriteLine("Please Enter a Product Name");
                    string p_ProductName = Console.ReadLine();
                    while(string.IsNullOrEmpty(p_ProductName))
                    {
                        Console.WriteLine("Product Name must have an input. Please Enter Product Name.");
                        p_ProductName =Console.ReadLine();
                    }
                    Console.WriteLine("Please Enter a Product Company");
                    string p_ProductComp = Console.ReadLine();
                    while(string.IsNullOrEmpty(p_ProductComp))
                    {
                        Console.WriteLine("Product Company must have an input. Please Enter Product Company.");
                        p_ProductComp =Console.ReadLine();
                    }
                    Console.WriteLine("Please Enter a StoreID");
                    int p_ProductStoreID = Convert.ToInt32(Console.ReadLine());
                    while(p_ProductStoreID >= 0)
                    {
                        Console.WriteLine("Store ID must have a positive value. Please enter a VALID Store ID");
                        p_ProductComp =Console.ReadLine();
                    }
                    //Display Logic for Search Function
                    List<Products> listofproducts = _productBL.SearchProducts(p_ProductName, p_ProductComp, p_ProductStoreID);
                    foreach (var Product in listofproducts)
                    {
                        Console.WriteLine(Product);
                    }
                    Console.WriteLine("Press Enter");
                    Console.ReadLine();
                    return "SearchProductsMenu";



                case "2":
                    Console.WriteLine("Please Enter a Product Category");
                    string p_ProductCat = Console.ReadLine();
                    while(string.IsNullOrEmpty(p_ProductCat))
                    {
                        Console.WriteLine("Product Category must have an input. Please Enter Product Category.");
                        p_ProductCat =Console.ReadLine();
                    }

                    //***TODO***: Display Logic for Search Function - Add full iteration to actual method
                    List<Products> listofproducts2 = _productBL.SearchProductsCat(p_ProductCat);
                    foreach (var Product in listofproducts2)
                    {
                        Console.WriteLine(Product);
                    }
                    Console.WriteLine("Press Enter");
                    Console.ReadLine();
                    return "SearchProductsMenu";



                case "3":
                    Console.WriteLine("Please Enter a Product Company");
                    string p_ProductComp2 = Console.ReadLine();
                    while(string.IsNullOrEmpty(p_ProductComp2))
                    {
                        Console.WriteLine("Product Company must have an input. Please Enter a Product Company Name");
                        p_ProductComp2 =Console.ReadLine();

                    }

                    //***TODO***: Display Logic for Search Function - Add full iteration to actual method
                    List<Products> listofproducts3 = _productBL.SearchProductsComp(p_ProductComp2);
                    foreach (var Product in listofproducts3)
                    {
                        Console.WriteLine(Product);
                    }
                    Console.WriteLine("Press Enter");
                    Console.ReadLine();
                    return "SearchProductsMenu";


                default:
                    Console.WriteLine("Customer not Found");
                    Console.WriteLine("Press Enter");
                    Console.ReadLine();
                    return "SearchProductsMenu";
            }
        }
    }
}