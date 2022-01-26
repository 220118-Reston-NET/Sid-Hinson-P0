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
IStoreMenu mainmenu = new StoreMenu();
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
            Log.Information("Displaying SearchPokemon Menu to user");
            //Variance ; Derived Class
            //Points Interface mainmenu at a new StoreMenu object
            mainmenu = new StoreMenu();
            break;
        case "Exit":
            isValid = false;
            break;
        case "AddCustomer":
            //Variance ; Derived Class
            //Business Layer Dependency which also depends on Repository
            //Points mainmenu to a new Add Customer Class Object
            //The Add Customer class has a private interface constructor method which excepts an IstoreBL obj
            //The MyStoreBL in turns excepts a Repostory obj
            Log.Information("Displaying SearchPokemon Menu to user");
            mainmenu = new AddCustomer(new MyStoreBL(new Repository()));
            break;
        // case "SearchCustomers":
        //     Log.Information("Displaying SearchPokemon Menu to user");

        default:
            Console.WriteLine("No Page Found");
            break;

    }
}

