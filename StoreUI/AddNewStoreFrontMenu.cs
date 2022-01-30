using StoreModel;
using StoreBL;
namespace StoreUI
{
    public class NewStoreFrontMenu : IMenu
    {
        //Static Class for variable Consistently Across the Created Class Objects
        private static StoreFronts _newStoreFronts = new StoreFronts();
        //Dependency Injection
        private IStoreFrontsBL _frontBL;
        //
        public NewStoreFrontMenu(IStoreFrontsBL p_front)
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
            Console.WriteLine("=[1] - Enter StoreFront Number" + _newStoreFronts.storeNumber );
            Console.WriteLine("=[2] - Enter StoreFront Street Address" + _newStoreFronts.storeAddress );
            Console.WriteLine("=[2] - Enter StoreFront Zipcode" + _newStoreFronts.storeZipCode );
            Console.WriteLine("=[2] - Enter StoreFront State" + _newStoreFronts.storeState);
            Console.WriteLine("=[3] - Update & Save Information");
            Console.WriteLine("===============================================");
        }

        public string UserSelection()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    return "MainMenu";
                case "1":
                    Console.WriteLine("Enter a Store Number :");
                    _newStoreFronts.storeNumber = Convert.ToInt32(Console.ReadLine());
                    return "AddStoreFronts";
                case "2":
                    Console.WriteLine("Enter a Street Address : ");
                    _newStoreFronts.storeAddress = Console.ReadLine();
                    return "AddStoreFronts";
                case "3":
                    Console.WriteLine("Enter a Zip Code : ");
                    _newStoreFronts.storeZipCode = Console.ReadLine();
                    return "AddStoreFronts";
                case "7":
                    try
                    {   
                        _frontBL.AddStoreFronts(_newStoreFronts);
                        Console.WriteLine("New StoreFronts was Saved to Database");
                        Console.WriteLine("Press Enter to Continue");
                        Console.ReadLine();

                    }
                    catch (System.Exception exc)
                    {
                        Console.WriteLine(exc.Message);
                        Console.WriteLine("Something Unexpected Happened");
                        Console.WriteLine("Press Enter to Continue");
                        Console.ReadLine();
                    }
                    return "MainMenu";
                    default:
                    return "AddStoreFronts";
            }
        }
    }
}