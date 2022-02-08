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
                    //Grab Product name
                    Console.WriteLine("Please Enter a Product Name");
                    string p_ProductName = Console.ReadLine();
                    while(string.IsNullOrEmpty(p_ProductName))
                    {
                        Console.WriteLine("Product Name must have an input. Please Enter Product Name.");
                        p_ProductName =Console.ReadLine();
                    }

                    //Grab Company
                    Console.WriteLine("Please Enter a Product Company");
                    string p_ProductComp = Console.ReadLine();
                    while(string.IsNullOrEmpty(p_ProductComp))
                    {
                        Console.WriteLine("Product Company must have an input. Please Enter Product Company.");
                        p_ProductComp =Console.ReadLine();
                    }

                    //Grab Store Id
                    Console.WriteLine("Please Enter a StoreID");

                    //Testing for an Integer Value
                    bool isNumber = false;
                    string Test = Console.ReadLine();
                    isNumber = int.TryParse(Test, out int p_ProductStoreID);
                    while(isNumber == false)
                    {
                        Console.WriteLine("You Must Enter an Integer value:");
                        string Retry = Console.ReadLine();
                        isNumber = int.TryParse(Retry, out int result);
                        p_ProductStoreID = result;
                    }
                    
                    //Get products by Criteria
                    List<Products> listofproducts = _productBL.SearchProducts(p_ProductName, p_ProductComp, p_ProductStoreID);
                    if(listofproducts.Any())
                    {
                        //Return Product
                        foreach (var Product in listofproducts)
                        {
                            Console.WriteLine(Product);
                        }
                        Console.WriteLine("Press Enter");
                        Console.ReadLine();
                        return "SearchProductsMenu";
                    }
                    else
                    {
                        //Confirm to User no result
                        Console.WriteLine("Your search did not return any results. Please try again");
                        Console.WriteLine("Press Enter to Continue");
                        Console.ReadLine();
                        return "SearchCustomersMenu";
                    }



                case "2":
                    Console.WriteLine("Please Enter a Product Category");
                    string p_ProductCat = Console.ReadLine();
                    while(string.IsNullOrEmpty(p_ProductCat))
                    {
                        Console.WriteLine("Product Category must have an input. Please Enter Product Category.");
                        p_ProductCat =Console.ReadLine();
                    }

                    //Get products by Category
                    List<Products> listofproducts2 = _productBL.SearchProductsCat(p_ProductCat);
                    if(listofproducts2.Any())
                    {
                        //Return Product
                        foreach (var Product in listofproducts2)
                        {
                            Console.WriteLine(Product);
                        }
                        Console.WriteLine("Press Enter");
                        Console.ReadLine();
                        return "SearchProductsMenu";
                    }
                    else
                    {
                        //Confirm to User no result
                        Console.WriteLine("Your search did not return any results. Please try again");
                        Console.WriteLine("Press Enter to Continue");
                        Console.ReadLine();
                        return "SearchCustomersMenu";
                    }




                case "3":
                    Console.WriteLine("Please Enter a Product Company");
                    string p_ProductComp2 = Console.ReadLine();
                    while(string.IsNullOrEmpty(p_ProductComp2))
                    {
                        Console.WriteLine("Product Company must have an input. Please Enter a Product Company Name");
                        p_ProductComp2 =Console.ReadLine();

                    }

                    //Get products by Company
                    List<Products> listofproducts3 = _productBL.SearchProductsComp(p_ProductComp2);
                    if(listofproducts3.Any())
                    {
                        //Return Product
                        foreach (var Product in listofproducts3)
                        {
                            Console.WriteLine(Product);
                        }
                        Console.WriteLine("Press Enter");
                        Console.ReadLine();
                        return "SearchProductsMenu";
                    }
                    else
                    {
                        //Confirm to User no result
                        Console.WriteLine("Your search did not return any results. Please try again");
                        Console.WriteLine("Press Enter to Continue");
                        Console.ReadLine();
                        return "SearchCustomersMenu";
                    }




                default:
                    Console.WriteLine("Customer not Found");
                    Console.WriteLine("Press Enter");
                    Console.ReadLine();
                    return "SearchProductsMenu";
            }
        }
    }
}