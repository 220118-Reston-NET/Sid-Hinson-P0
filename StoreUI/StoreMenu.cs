namespace StoreUI
{

    /// <summary>
    /// Store Menu Inherits Interface --> Entry Point
    /// User Selection Methods Implemented
    /// </summary>
    public class StoreMainUI : IStoreMenu
    {
        /// <summary>
        /// Displays Store Menu
        /// </summary>
        public void MenuDisplay()
        {
            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("=            Welcome To            =");
            Console.WriteLine("=    Retro Barbarian Gaming Lair   =");
            Console.WriteLine("====================================");
            Console.WriteLine("=     Please Make a Selection      =");
            Console.WriteLine("=      [0] Exit The Store          =");
            Console.WriteLine("=      [1] Add A New Customer      =");
            Console.WriteLine("=      [2] Search For Customers    =");       
            Console.WriteLine("====================================");
        }

        /// <summary>
        /// Get User Input and Select Case Choice
        /// </summary>
        /// <returns>Returns String Selection</returns>
        public string UserSelection()
        {
            //Read in Customer Input 
            string UserInput = Console.ReadLine();

            switch (UserInput)
            {
                case "0":
                    return "Exit";
                case "1":
                    return "AddCustomer";
                case "2":
                    return "SearchCustomerMenu";
                default :
                    Console.WriteLine("Selection Invalid");
                    Console.WriteLine("Press Enter");
                    Console.ReadLine();
                    return "MainMenu";

            }
        }
    }
}