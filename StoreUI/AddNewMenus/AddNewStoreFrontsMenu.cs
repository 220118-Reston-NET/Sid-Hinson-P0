using StoreModel;
using StoreBL;
namespace StoreUI
{
    public class NewStoreFrontsMenu : IMenu
    {
        //Static Class for variable Consistently Across the Created Class Objects
        private static StoreFronts _newStoreFronts = new StoreFronts();
        //Dependency Injection
        private IStoreFrontsBL _frontBL;
        //
        public NewStoreFrontsMenu(IStoreFrontsBL p_front)
        {
            _frontBL = p_front;
        }
        public void MenuDisplay()
        {
            Console.Clear();
            Console.WriteLine("================================================");
            Console.WriteLine("=             Menu : Add StoreFront            =");
            Console.WriteLine("===============================================");
            Console.WriteLine("=       Enter New StoreFronts Info : Select       =");     
            Console.WriteLine("================================================");
            Console.WriteLine("=[0] - Return to Main Menu");
            Console.WriteLine("=[1] - Enter StoreFront Street Address: " + _newStoreFronts.StoreAddress );
            Console.WriteLine("=[2] - Enter StoreFront City: " + _newStoreFronts.StoreCity );        
            Console.WriteLine("=[3] - Enter StoreFront Zipcode: " + _newStoreFronts.StoreZipCode );
            Console.WriteLine("=[4] - Enter StoreFront State: " + _newStoreFronts.StoreState);
            Console.WriteLine("=[5] - Update & Save Information");
            Console.WriteLine("===============================================");
            Console.WriteLine("=========================================================="); 
            Console.WriteLine(")xxxxx[;;;;;;;;;>    )xxxxx[;;;;;;;;;>   )xxxxx[;;;;;;;;;>"); 
            Console.WriteLine("==========================================================");
        }

        public string UserSelection()
        {
            Log.Information("User is inputting the Menu Selection");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    Log.Information("User is selecting Store Main Menu");
                    return "StoreMainMenu";


                case "1":
                    Log.Information("User is inputting the Store Front Street Address");
                    Console.WriteLine("Enter a Street Address : ");
                    _newStoreFronts.StoreAddress = Console.ReadLine();
                    _newStoreFronts.StoreAddress= _newStoreFronts.StoreAddress.ToUpper();
                    //Test for Null/Empty
                    while(string.IsNullOrEmpty(_newStoreFronts.StoreAddress))
                    {
                        Console.WriteLine("Selection must have an input. Please Enter a Menu selection.");
                       _newStoreFronts.StoreAddress = Console.ReadLine();
                       _newStoreFronts.StoreAddress= _newStoreFronts.StoreAddress.ToUpper();

                    }
                    return "NewStoreFrontsMenu";


                case "2":
                    Log.Information("User is inputting the Store Front City");
                    Console.WriteLine("Enter a Store City : ");
                    _newStoreFronts.StoreCity = Console.ReadLine();
                    _newStoreFronts.StoreCity = _newStoreFronts.StoreCity.ToUpper();
                    //Test for Null/Empty
                    while(string.IsNullOrEmpty(_newStoreFronts.StoreCity))
                    {
                        Console.WriteLine("Selection must have an input. Please Enter a Menu selection.");
                      _newStoreFronts.StoreCity = Console.ReadLine();
                      _newStoreFronts.StoreCity = _newStoreFronts.StoreCity.ToUpper();

                    }
                    return "NewStoreFrontsMenu";


                case "3":
                   Log.Information("User is inputting the Store Front Zip Code");
                    Console.WriteLine("Enter a Zip Code : ");
                   _newStoreFronts.StoreZipCode = Console.ReadLine();
                    bool isNumber = false;
                    //Test for Format
                    do
                    {
                       Console.WriteLine("Selection must have an input. Please Enter a Menu selection.");
                       _newStoreFronts.StoreZipCode = Console.ReadLine();
                       
                       string Test2 = _newStoreFronts.StoreZipCode;
                       isNumber = int.TryParse(Test2, out int z);
                       while(isNumber == false)
                        {
                            Console.WriteLine("You Must Enter an 5 Digit Numerical ZipCode");
                            string Retry = Console.ReadLine();
                            isNumber = int.TryParse(Retry, out int result);
                            _newStoreFronts.StoreZipCode = Convert.ToString(result);
                        }     
                    }
                    while(string.IsNullOrEmpty(_newStoreFronts.StoreZipCode) || _newStoreFronts.StoreZipCode.Length > 5 || _newStoreFronts.StoreZipCode.Length < 5 ||  isNumber == false);
                    return "NewStoreFrontsMenu";


                case "4":
                   Log.Information("User is inputting the Store Front State");
                    Console.WriteLine("Enter a State Location : ");
                    _newStoreFronts.StoreState = Console.ReadLine();
                    _newStoreFronts.StoreState = _newStoreFronts.StoreState.ToUpper();
                         bool isANumber = false;
                    //Test for Format
                    do
                    {
                        Console.WriteLine("Selection must have a valid input. Please enter on next line :");
                        _newStoreFronts.StoreZipCode = Console.ReadLine();
                        _newStoreFronts.StoreZipCode = _newStoreFronts.StoreZipCode.ToUpper();
                        string Test1 = _newStoreFronts.StoreZipCode;
                        isANumber = int.TryParse(Test1, out int x);
                        _newStoreFronts.StoreZipCode = Test1;
                        _newStoreFronts.StoreZipCode = _newStoreFronts.StoreZipCode.ToUpper();
                        while(isANumber == true)
                        {
                            Console.WriteLine("You Must Enter Alphabetical Characaters. Please enter on next line:");
                            string Retry = Console.ReadLine();
                            isANumber = int.TryParse(Retry, out int result);
                            _newStoreFronts.StoreZipCode = Retry;
                            _newStoreFronts.StoreZipCode = _newStoreFronts.StoreZipCode.ToUpper();
                        }

                    }while(string.IsNullOrEmpty(_newStoreFronts.StoreZipCode) || _newStoreFronts.StoreZipCode.Length > 2 || _newStoreFronts.StoreZipCode.Length < 2 || isANumber == true);
                    return "NewStoreFrontsMenu";

                //*************TODO: Validation check Method on all Inputs
                case "5":
                    Log.Information("User is attempting to save the Store Front to The DB");
                    try
                    {   
                        _frontBL.AddStoreFronts(_newStoreFronts);

                    }
                    catch (System.Exception exc)
                    {
                        Console.WriteLine(exc.Message);
                        Console.WriteLine("Something Unexpected Happened");
                        Console.WriteLine("Press Enter to Continue");
                        Console.ReadLine();
                    }
                    return "NewStoreFrontsMenu";

                    
                    default:
                    Log.Information("User has made an Invalid Selection");
                    Console.WriteLine("You have made an Invalid Selection - Please Press Enter to Continue");
                    Console.ReadLine();
                    return "NewStoreFrontsMenu";
            }
        }
    }
}