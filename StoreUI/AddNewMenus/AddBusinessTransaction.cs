using StoreModel;
using StoreBL;
namespace StoreUI
{
    public class AddBusinessTransaction : IMenu
    {

        public void MenuDisplay()
        {
            Console.Clear();
            Console.WriteLine("=========================================================="); 
            Console.WriteLine(")xxxxx[;;;;;;;;;>    )xxxxx[;;;;;;;;;>   )xxxxx[;;;;;;;;;>"); 
            Console.WriteLine("==========================================================");
            Console.WriteLine("     ================================================");
            Console.WriteLine("     = Retro Barbarian Online Gaming Lair Shop Menu =");
            Console.WriteLine("     ================================================");
            Console.WriteLine("     =         Enter Number to Select Option        =");     
            Console.WriteLine("     ================================================");
            Console.WriteLine("     =[0]     - Return to Main Menu / Exit          =");
            Console.WriteLine("     =[1]     - Display Product By Category         =");
            Console.WriteLine("     =[2]     - Search For Products by Criteria     =");
            Console.WriteLine("     =[3]     - Create/Edit Product Order           =");
            Console.WriteLine("     =[4]     - View Your Order History             =");
            Console.WriteLine("===========================================================");
            Console.WriteLine("=========================================================="); 
            Console.WriteLine(")xxxxx[;;;;;;;;;>    )xxxxx[;;;;;;;;;>   )xxxxx[;;;;;;;;;>"); 
            Console.WriteLine("==========================================================");
        }

        public string UserSelection()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                //Return to Main Menu
                case "0":
                return "CustomersMenu";


                //Display Products by Category
                case "1":
                return "AddProductsDisplay";

                //Search Products by Criteria
                case "2":
                return "SearchProductsMenu"; 


                //Create Edit Orders
                case "3":
                return "AddNewOrderMenu";


                //View Order History
                //TODO ***********Implement ***********
                case "4":
                Console.WriteLine("Not Implemented Yet- press Enter");
                Console.ReadLine();
                return "AddBusinessTransaction";

                //Default Case
                default:
                return "AddBusinessTransaction";
            }
        }
    }
}