using StoreModel;
using StoreBL;
namespace StoreUI
{
    public class StoreShopMenu : IOrdersMenu
    {

        public void MenuDisplay()
        {
            Console.Clear();
            Console.WriteLine("================================================");
            Console.WriteLine("=    Retro Barbarian Gaming Lair Shop Menu     =");
            Console.WriteLine("================================================");
            Console.WriteLine("=          Enter Number to Select Option       =");     
            Console.WriteLine("================================================");
            Console.WriteLine("=[0] - Return to Main Menu / Exit              =");
            Console.WriteLine("=[1] - Log In To Enable Shopping               =");
            Console.WriteLine("=[2] - Shop for Products                       =");
            Console.WriteLine("=[3] - Remove Products From Order              =");
            Console.WriteLine("=[4] - Remove ALL Products From Order          =");
            Console.WriteLine("=[5] - Finalize Customer Order                 =");
            Console.WriteLine("================================================");
        }

        public string UserSelection()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    return "MainMenu";
                case "1":
                    return "NewCustomersMenu";
                case "2":
                    return "MainMenu";
                case "3":
                    return "StoreShopMenu";                    
                default:
                    return "MainMenu";
            }
        }
    }
}