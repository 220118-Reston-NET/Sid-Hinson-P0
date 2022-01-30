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
Log.Logger = new LoggerConfiguration()
    .WriteTo.File("./Logs/User.txt") 
    .CreateLogger();


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
        case "MainMenu":
            Log.Information("Displaying Main Menu to user");
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
        case "CustomerMenu":
            mainmenu = new CustomerMenu();
            break;
        case "NewCustomerMenu":
            Log.Information("Displaying New Customer Menu to user");
            mainmenu = new NewCustomersMenu(new CustomersBL(new CustomersRepository()));
            break;
        case "SearchCustomerMenu":
            Log.Information("Displaying Search Results Menu to user");
            mainmenu = new SearchCustomersMenu(new CustomersBL(new CustomersRepository()));
            break;
        case "NewStoreFrontMenu":
            mainmenu = new NewStoreFrontsMenu(new StoreFrontsBL(new StoreFrontsRepository()));
            break;
        case "SearchStoreFrontMenu":
            mainmenu = new NewStoreFrontsMenu(new StoreFrontsBL(new StoreFrontsRepository()));
            break;
        case "NewProductMenu":
            mainmenu = new NewProductsMenu(new ProductsBL(new ProductsRepository()));
            break;
        case "SearchProductsMenu":
            mainmenu = new SearchProductsMenu(new ProductsBL(new ProductsRepository()));
            break;
        case "Exit":
            Log.Information("User has Exited The Program");
            Log.CloseAndFlush(); //To close our logger resource
            isValid = false;
            break;
        default:
            Log.Information("User input wrong selection");
            Console.WriteLine("No Page Found!");
            Console.WriteLine("Press Enter to Continue");
            Console.ReadLine();
            break;

    }
}

