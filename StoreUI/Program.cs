global using Serilog;
using StoreUI;
using StoreDL;
using StoreBL;


/// <summary>
/// Program Menu Logic Methods; Boolean While Loop
/// </summary>
/// <returns>User String Selections</returns>


///Creating Logger and Configuration
Log.Logger = new LoggerConfiguration()
    .WriteTo.File("./Logs/User.txt") 
    .CreateLogger();

bool isValid = true;
//Interface object points to new StoreMenu
IStoreMenu mainmenu = new StoreMainUI();
while(isValid)
{
    
    //Points IStoreMenu at new StoreMenu() object
    //These use the Interface Methods which were implemented in StoreMenu
    mainmenu.MenuDisplay();
    string userInput = mainmenu.UserSelection();

    //Accepts User Input to Make a case switch
    switch(userInput)
    {
        case "MainMenu":
            Log.Information("Displaying Main Menu to user");
            //Variance ; Derived Class
            //Points Interface mainmenu at a new StoreMenu object
            mainmenu = new StoreMainUI();
            break;
        case "Exit":
            isValid = false;
            break;
        case "AddCustomer":
            //Variance ; Derived Class
            //Business Layer Dependency which also depends on Repository
            Log.Information("Displaying Add Customers Menu to user");
            mainmenu = new AddCustomerMenu(new MyStoreBL(new Repository()));
            break;
        case "SearchCustomerMenu":
            Log.Information("Displaying Search Results Menu to user");
            mainmenu = new SearchCustomersMenu(new MyStoreBL(new Repository()));
            break;
        default:
            Console.WriteLine("No Page Found!");
            Console.WriteLine("Press Enter to Continue");
            Console.ReadLine();
            break;

    }
}

