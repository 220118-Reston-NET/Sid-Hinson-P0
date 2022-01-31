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
            Console.WriteLine("============================================");
            Console.WriteLine("=          Menu : Search Products          =");
            Console.WriteLine("============================================");
            Console.WriteLine("=              Select Option :             =");
            Console.WriteLine("= [0] - Exit Search                        =");
            Console.WriteLine("= [1] - Find Product by Name               =");
            Console.WriteLine("= [2] - Find Product by Category           =");
            Console.WriteLine("= [3] - Find Product by Company            =");    
            Console.WriteLine("============================================");
        }

        public string UserSelection()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return "MainMenu";
                case "1":
                    Console.WriteLine("Please Enter a Product Name");
                    string p_productName = Console.ReadLine();
                    //Display Logic for Search Function
                    List<Products> listofproducts = _productBL.SearchProducts(p_productName);
                    foreach (var Product in listofproducts)
                    {
                        Console.WriteLine(Product);
                    }
                    Console.WriteLine("Press Enter");
                    Console.ReadLine();
                    return "SearchProductsMenu";
                case "2":
                    Console.WriteLine("Please Enter a Product Category");
                    string p_productCat = Console.ReadLine();
                    //Display Logic for Search Function
                    List<Products> listofproducts2 = _productBL.SearchProductsCat(p_productCat);
                    foreach (var Product in listofproducts2)
                    {
                        Console.WriteLine(Product);
                    }
                    Console.WriteLine("Press Enter");
                    Console.ReadLine();
                    return "SearchProductsMenu";
                case "3":
                    Console.WriteLine("Please Enter a Product Company");
                    string p_productComp = Console.ReadLine();
                    //Display Logic for Search Function
                    List<Products> listofproducts3 = _productBL.SearchProductsComp(p_productComp);
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