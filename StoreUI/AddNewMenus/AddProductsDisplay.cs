using StoreModel;
using StoreBL;
namespace StoreUI
{
    public class AddProductsDisplay : IMenu
    {
        //Dependency Injection
        private IProductsBL _productBL;
        private IOrdersBL _orderBL;
        private ICustomersBL _customerBL;
        
        public AddProductsDisplay(IOrdersBL p_orderBL, IProductsBL p_productBl, ICustomersBL p_customerBL)
        {
            _orderBL = p_orderBL;
            _productBL = p_productBl;
            _customerBL = p_customerBL;
        }
        public void MenuDisplay()
        {
            Console.Clear();
            Console.WriteLine("********************************************************************************");
            Console.WriteLine("*        Retro Barbarian Gaming Lair Has (3) Locations to Serve You            *");
            Console.WriteLine("********************************************************************************");
            Console.WriteLine("*               Please Enter a Store Front Number (1-3)                        *");
            Console.WriteLine("*                           You will Need:                                     *");
            Console.WriteLine("*          a Product Name, Company Name, StoreID and Quantity                  *");
            Console.WriteLine("*                to Order Products From This Terminal                          *");
            Console.WriteLine("********************************************************************************");
            Console.WriteLine("*                        Press Enter When Ready                                *");
            Console.WriteLine("********************************************************************************");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("*******************************************************************");
            Console.WriteLine("***** Enter a Category To See Inventory - Games - or - Systems ****");
            Console.WriteLine("*******************************************************************");
            Console.WriteLine("*[0] = EXIT      [1] = Games     [2] = Systems   [3] = Merchandise*");
            Console.WriteLine("*******************************************************************");
        }

        public string UserSelection()
        {
            
            string userInput = Console.ReadLine();
            switch(userInput)
            {
                case "0":
                return "NewCustomerOrderMenu";



                case "1":
                string answer1 = "Games";
                List<Products> listofprod1 = _productBL.SearchProductsCat(answer1);
                    foreach (var Products in listofprod1)
                    {
                        Console.WriteLine("***********************");
                        Console.WriteLine(Products);
                        Console.WriteLine("***********************");
                    }
                    Console.WriteLine("Press Enter to Continue");
                    Console.ReadLine();
                return "AddProductsDisplay";



                case "2":
                string answer2 = "System";
                List<Products> listofprod2 = _productBL.SearchProductsCat(answer2);
                    foreach (var Products in listofprod2)
                    {
                        Console.WriteLine("***********************");
                        Console.WriteLine(Products);
                        Console.WriteLine("***********************");
                    }
                    Console.WriteLine("Press Enter to Continue");
                    Console.ReadLine();
                return "AddProductsDisplay";



                case "3":
                string answer3 = "Merchandise";
                List<Products> listofprod3 = _productBL.SearchProductsCat(answer3);
                    foreach (var Products in listofprod3)
                    {
                        Console.WriteLine("***********************");
                        Console.WriteLine(Products);
                        Console.WriteLine("***********************");
                    }
                    Console.WriteLine("Press Enter to Continue");
                    Console.ReadLine();
                return "AddProductsDisplay";  



                default:
                return "AddProductsDisplay";
             }
        }
    }
}















                


   