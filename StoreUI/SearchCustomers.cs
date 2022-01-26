// namespace StoreUI
// {
//     public class SearchCustomers : IStoreMenu
//     {
//         public void MenuDisplay()
//         {   
//             Console.WriteLine("============================================");
//             Console.WriteLine("=          Menu : Search Customers          ");
//             Console.WriteLine("============================================");
//             Console.WriteLine("=");
//             Console.WriteLine("=");
//             Console.WriteLine("=");
//             Console.WriteLine("============================================");
//         }

//         public string UserSelection()
//         {
//             string userInput = Console.ReadLine();

//             switch (userInput)
//             {
//                 case "0":
//                     return "MainMenu";
//                 case "1":
//                     Console.WriteLine("Please Enter a Name");
//                     string name = Console.ReadLine();
//                     List<Customer> listofcustomers = _pokeBL.SearchCustomers(name);
//                     return "";
//                 default:
//                     Console.WriteLine("Selection Invalid");
//                     Console.WriteLine("Press Enter");
//                     Console.ReadLine();
//                     return "MainMenu";
//             }
//         }
//     }

// }