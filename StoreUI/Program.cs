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
        case "AdministrationMenu":
            AdminValidate admin = new AdminValidate();
            bool uservalidate = admin.ValidateAdminPassword();
            if (uservalidate == true)
            {
                mainmenu =  new AdministrationMenu();
            }
            else
            {
                Console.WriteLine("Incorrect Password");
                mainmenu = new StoreMainMenu();
                break;
            }
            break;
        // case "AddCustomer":
        //     //Variance ; Derived Class
        //     //Business Layer Dependency which also depends on Repository
        //     Log.Information("Displaying Add Customers Menu to user");
        //     mainmenu = new AddCustomerMenu(new CustomersBL(new CustomersRepository()));
        //     break;
        // case "SearchCustomerMenu":
        //     Log.Information("Displaying Search Results Menu to user");
        //     mainmenu = new SearchCustomersMenu(new CustomersBL(new CustomersRepository()));
        //     break;
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

