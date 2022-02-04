global using Serilog;
using StoreUI;
using StoreModel;
using StoreDL;
using StoreBL;


/// <summary>
/// Program Menu Logic Methods; Boolean While Loop
/// </summary>
/// <returns>User String Selections</returns>


/// <summary>
/// Creates Logger and Config
/// </summary>
/// <returns></returns>
// Log.Logger = new LoggerConfiguration()
    // .WriteTo.File("./Logs/User.txt") 
    // .CreateLogger();


/// <summary>
/// Program Runtime Logic
/// </summary>
bool isValid = true;
IMenu mainmenu = new StoreMainMenu();
while(isValid)
{
    mainmenu.MenuDisplay();
    string userInput = mainmenu.UserSelection();


    switch(userInput)
    {
        case "StoreMainMenu":
            // Log.Information("Displaying Main Menu to user");
            mainmenu = new StoreMainMenu();
            break;
        //Added in very primtive password protection : Pass is "8675309"
        //Added in For Effect ONLY; to be implemented better in future projects
        case "AdministrationMenu":
            // AdminValidate admin = new AdminValidate();
            // bool uservalidate = admin.ValidateAdminPassword();
            // if (uservalidate == true)
            // {
            //     mainmenu =  new AdministrationMenu();
            // }
            // else
            // {
            //     Console.WriteLine("Incorrect Password");
            //     mainmenu = new StoreMainMenu();
            //     break;
            // }
            // break;
            mainmenu =  new AdministrationMenu();
            break;
        case "CustomersMenu":
            mainmenu = new CustomersMenu();
            break;
        case "NewCustomersMenu":
            // Log.Information("Displaying New Customer Menu to user");
            mainmenu = new NewCustomersMenu(new CustomersBL(new CustomersRepository()));
            break;
        case "SearchCustomersMenu":
            // Log.Information("Displaying Search Results Menu to user");
            mainmenu = new SearchCustomersMenu(new CustomersBL(new CustomersRepository()));
            break;
        case "NewStoreFrontsMenu":
            mainmenu = new NewStoreFrontsMenu(new StoreFrontsBL(new StoreFrontsRepository()));
            break;
        case "SearchStoreFrontsMenu":
            mainmenu = new SearchStoreFrontsMenu(new StoreFrontsBL(new StoreFrontsRepository()));
            break;
        case "AddNewProductsMenu":
            mainmenu = new AddNewProductsMenu(new ProductsBL(new ProductsRepository()));
            break;
        case "SearchProductsMenu":
            mainmenu = new SearchProductsMenu(new ProductsBL(new ProductsRepository()));
            break;
        case "AddNewOrderMenu":
            mainmenu = new AddNewOrderMenu(new OrdersBL(new OrdersRepository()), new ProductsBL(new ProductsRepository()), new CustomersBL(new CustomersRepository()));
            break;
        case "AddBusinessTransaction":
            mainmenu = new AddNewOrderMenu(new OrdersBL(new OrdersRepository()), new ProductsBL(new ProductsRepository()), new CustomersBL(new CustomersRepository()));
            break;
        case "AddProductsDisplay":
            mainmenu = new AddProductsDisplay(new OrdersBL(new OrdersRepository()), new ProductsBL(new ProductsRepository()), new CustomersBL(new CustomersRepository()));
            break;
        case "Exit":
            // Log.Information("User has Exited The Program");
            // Log.CloseAndFlush(); //To close our logger resource
            isValid = false;
            break;
        default:
            // Log.Information("User input wrong selection");
            Console.WriteLine("No Page Found!");
            Console.WriteLine("Press Enter to Continue");
            Console.ReadLine();
            mainmenu = new StoreMainMenu();
            break;

    }
}

