namespace StoreUI
{

    /// <summary>
    /// Store Menu Inherits Interface --> Entry Point
    /// User Selection Methods Implemented
    /// </summary>
    public class StoreMainMenu : IMenu
    {
        /// <summary>
        /// Displays Store Menu
        /// </summary>
        public void MenuDisplay()
        {
            Console.Clear();
            Console.WriteLine("=========================================================="); 
            Console.WriteLine(")xxxxx[;;;;;;;;;>    )xxxxx[;;;;;;;;;>   )xxxxx[;;;;;;;;;>"); 
            Console.WriteLine("==========================================================");
            Console.WriteLine("         ====================================");
            Console.WriteLine("         =            Welcome To            =");
            Console.WriteLine("       =    Retro Barbarian Online Gaming Lair   =");
            Console.WriteLine("         ====================================");
            Console.WriteLine("         =     Please Make a Selection      =");
            Console.WriteLine("         =      [0] Exit The Store          =");
            Console.WriteLine("         =      [1] Customer Menu           =");
            Console.WriteLine("         =      [2] Administration Menu     =");       
            Console.WriteLine("         ====================================");
            Console.WriteLine("=========================================================="); 
            Console.WriteLine(")xxxxx[;;;;;;;;;>    )xxxxx[;;;;;;;;;>   )xxxxx[;;;;;;;;;>"); 
            Console.WriteLine("==========================================================");
        }

        /// <summary>
        /// Get User Input and Select Case Choice
        /// </summary>
        /// <returns>Returns String Selection</returns>
        public string UserSelection()
        {
            //Read in Customer Input 
            string UserInput = Console.ReadLine();
            while(string.IsNullOrEmpty(UserInput))
            {
                Console.WriteLine("Please Input a Selection");
                UserInput = Console.ReadLine();
            }
            switch (UserInput)
            {
                case "0":
                    return "Exit";
                case "1":
                    return "CustomersMenu";
                case "2":
                    return "AdministrationMenu";
                default :
                    Console.WriteLine("Selection Invalid");
                    Console.WriteLine("Please Enter a Valid Selection from the Menu");
                    Console.ReadLine();
                    return "StoreMainMenu";

            }
        }
    }
}