using StoreModel;
using StoreBL;
namespace StoreUI
{
    public class SearchStoreFrontsMenu : IMenu
    {
        private IStoreFrontsBL _frontBL;

        public SearchStoreFrontsMenu(IStoreFrontsBL p_frontBL)
        {
            _frontBL = p_frontBL; 
        }
        public void MenuDisplay()
        {   
            Console.WriteLine("============================================");
            Console.WriteLine("=          Menu : Search StoreFronts       =");
            Console.WriteLine("============================================");
            Console.WriteLine("=              Select Option :             =");
            Console.WriteLine("= [0] - Exit Search                        =");
            Console.WriteLine("= [1] - Find StoreFront Information        =");
            Console.WriteLine("============================================");
        }

        public string UserSelection()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return "MainMenu";
                case "1":
                    Console.WriteLine("Please Enter a Store Front Number (1-10)");
                    int p_storeNumber = Convert.ToInt32(Console.ReadLine());
                    //Display Logic for Search Function
                    List<StoreFronts> listofStoreFronts = _frontBL.SearchStoreFronts(p_storeNumber);
                    foreach (var StoreFront in listofStoreFronts)
                    {
                        Console.WriteLine(StoreFront);
                    }
                    Console.WriteLine("Press Enter to Continue");
                    Console.ReadLine();
                    return "MainMenu";
                default:
                    Console.WriteLine("StoreFront not Found");
                    Console.WriteLine("Press Enter");
                    Console.ReadLine();
                    return "MainMenu";
            }
        }
    }
}