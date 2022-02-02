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
            Console.WriteLine("=[1] - Enter StoreFront Number: " + _newStoreFronts.StoreID );
            Console.WriteLine("=[2] - Enter StoreFront Street Address: " + _newStoreFronts.StoreAddress );
            Console.WriteLine("=[3] - Enter StoreFront City: " + _newStoreFronts.StoreCity );        
            Console.WriteLine("=[4] - Enter StoreFront Zipcode: " + _newStoreFronts.StoreZipCode );
            Console.WriteLine("=[5] - Enter StoreFront State: " + _newStoreFronts.StoreState);
            Console.WriteLine("=[6] - Update & Save Information");
            Console.WriteLine("===============================================");
        }

        public string UserSelection()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    return "StoreMainMenu";
                case "1":
                    Console.WriteLine("Enter a Store Number :");
                    _newStoreFronts.StoreID = Convert.ToInt32(Console.ReadLine());
                    return "NewStoreFrontsMenu";
                case "2":
                    Console.WriteLine("Enter a Street Address : ");
                    _newStoreFronts.StoreAddress = Console.ReadLine();
                    return "NewStoreFrontsMenu";
                case "3":
                    Console.WriteLine("Enter a Store City : ");
                    _newStoreFronts.StoreCity = Console.ReadLine();
                    return "NewStoreFrontsMenu";
                case "4":
                    Console.WriteLine("Enter a Zip Code : ");
                    _newStoreFronts.StoreZipCode = Console.ReadLine();
                    return "NewStoreFrontsMenu";
                case "5":
                    Console.WriteLine("Enter a State Location : ");
                    _newStoreFronts.StoreState = Console.ReadLine();
                    return "NewStoreFrontsMenu";               
                case "6":
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
                    return "NewStoreFrontsMenu";
            }
        }
    }
}