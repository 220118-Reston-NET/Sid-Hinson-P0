using StoreModel;
using StoreUI;

/// <summary>
/// Program Menu Logic Methods; Boolean While Loop
/// </summary>
/// <returns>User String Selections</returns>


bool isValid = true;
//Interface object points to new StoreMenu
IStoreMenu mainmenu = new StoreMenu();
while(isValid)
{
    
    mainmenu.MenuDisplay();
    string userInput = mainmenu.UserSelection();

    switch(userInput)
    {
        case "MainMenu":
            //Variance ; Derived Class
            mainmenu = new StoreMenu();
            break;
        case "Exit":
            isValid = false;
            break;
        case "AddCustomer":
            //Variance ; Derived Class
            mainmenu = new AddCustomer();
            break;
        default:
            Console.WriteLine("No Page Found");
            break;

    }
}

