using StoreBL;
using StoreModel;

namespace StoreUI
{

    public class AdminOrderMenu : IMenu
    {

        private IOrdersBL _ordBL;
        private ICustomersBL _custBL;
        private IStoreFrontsBL _storebl;
        public AdminOrderMenu(IOrdersBL p_ord, ICustomersBL p_cust, IStoreFrontsBL p_store)
        {
            _custBL = p_cust;
            _ordBL = p_ord;
            _storebl = p_store;
        }
        public void MenuDisplay()
        {
            Console.Clear();
            Console.WriteLine("================================================");
            Console.WriteLine("=          Menu : Order Administration         =");
            Console.WriteLine("================================================");
            Console.WriteLine("=       Check or Update Warehouse Products     =");     
            Console.WriteLine("================================================");
            Console.WriteLine("=[0] - Return to Main Menu");
            Console.WriteLine("=[1] - Check Order Status ");
            Console.WriteLine("=[2] - Change Order Status");
            Console.WriteLine("=[3] - Locate Customer Order by Cust/StoreID");
            Console.WriteLine("=[4] - Locate Customer ID Retrieval Tool");
            Console.WriteLine("=[5] - Show All Current Orders for a Given StoreFront");
            Console.WriteLine("=[6] - Show All Past Orders for a Given StoreFront");
            Console.WriteLine("===============================================");

        }

        public string UserSelection()
        {
            Log.Information("User is inputting the Menu Selection");
            string userInput = Console.ReadLine();
            switch(userInput)
            {
                case "0":
                    Log.Information("User is selecting Store Main Menu");
                    return "StoreMainMenu";
                    
                case "1":
                    Log.Information("User is selecting Check Order Status");
                    Console.WriteLine("Please Enter the Order ID");
                    int p_ordID = Convert.ToInt32(Console.ReadLine());
                    Orders foundord = _ordBL.SearchOrdStat(p_ordID);
                    Console.Clear();
                    _ordBL.DisplayGraphic();
                    Console.WriteLine("The Follwing Order Was Found");
                    Console.WriteLine(foundord);
                    Console.WriteLine("Press Enter to Return to Order Admin");
                    Console.ReadLine();
                    return "AdminOrderMenu";




                case "2":
                    Log.Information("User is selecting Change Order Status");
                    Console.WriteLine("Please Enter the Order ID");
                    int p_oID = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    _ordBL.DisplayGraphic();
                    Console.WriteLine("===================================");
                    Console.WriteLine("=Please Enter the New Order Status=");
                    Console.WriteLine("===================================");
                    Console.WriteLine("=[1] - PROCESSING");
                    Console.WriteLine("=[2] - FULFILLED");
                    Console.WriteLine("=[3] - CANCELLED");
                    Console.WriteLine("===================================");
                    string p_newos = Console.ReadLine();
                    switch(p_newos)
                    {   
                        case "1":
                        string answer1 = "PROCESSING";
                        _ordBL.UpdateOrdStat(p_oID, answer1);
                        Console.WriteLine("Order Updated");
                        Console.WriteLine("Press Enter to Continer");
                        Console.ReadLine();
                        return "AdminOrderMenu";
                        case "2":
                        string answer2 = "FULFILLED";
                        _ordBL.UpdateOrdStat(p_oID, answer2);
                        Console.WriteLine("Order Updated");
                        Console.WriteLine("Press Enter to Continer");
                        Console.ReadLine();
                        return "AdminOrderMenu";
                        case "3":
                        string answer3 = "CANCELLED";
                        _ordBL.UpdateOrdStat(p_oID, answer3);
                        Console.WriteLine("Order Updated");
                        Console.WriteLine("Press Enter to Continer");
                        Console.ReadLine();
                        return "AdminOrderMenu";
                        default:
                        Console.WriteLine("Invalid Selection.Press Enter to Continer");
                        Console.ReadLine();
                        return "AdminOrderMenu";

                    };


                case "3":
                    Log.Information("User is selecting Search for Customer Order");
                    Console.WriteLine("Please Enter a Customer ID");
                    int p_cID = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Please Enter a Store ID");
                    int p_sID = Convert.ToInt32(Console.ReadLine());
                    List<Orders> searchorder = _ordBL.Search4Order(p_cID, p_sID);
                    Console.Clear();
                    _ordBL.DisplayGraphic();
                    Console.WriteLine("The following orders were found:");
                    foreach(Orders ord in searchorder)
                    {
                        Console.WriteLine(ord);
                    }
                    Console.WriteLine("Press Enter to Return to Order Admin");
                    Console.ReadLine();
                    return "AdminOrderMenu";


                case "4":
                    Log.Information("User is selecting Search for Customer");
                    Console.WriteLine("Please enter Customer First Name:");
                    string p_f = Console.ReadLine();
                    p_f = p_f.ToUpper();
                    Console.WriteLine("Please enter Customer Last Name:");
                    string p_l = Console.ReadLine();
                    p_l = p_l.ToUpper();
                    Console.WriteLine("Please enter Customer City:");
                    string p_c = Console.ReadLine();
                    p_c = p_c.ToUpper();
                    Console.WriteLine("Please enter Customer State:");
                    string p_s = Console.ReadLine();
                    p_s = p_s.ToUpper();
                    List<Customers> searchcust = _custBL.Search4Customers(p_f,p_l,p_c,p_s);
                    Console.Clear();
                    _ordBL.DisplayGraphic();
                    Console.WriteLine("The following customers were found:");
                    foreach(Customers cust in searchcust)
                    {
                        Console.WriteLine(cust);
                    }
                    Console.WriteLine("Press Enter to Return to Order Admin");
                    Console.ReadLine();
                    return "AdminOrderMenu";


                case "5":
                    Log.Information("User is selecting Show CurrentAll Orders for a Store");
                    Console.WriteLine("Please Enter a Store ID");
                    int p_sCID = Convert.ToInt32(Console.ReadLine());
                    List<Orders> findcurrent = _ordBL.SearchStoreOrders(p_sCID, "PROCESSING");
                    Console.WriteLine("PROCESSING Orders:");
                    foreach(Orders ord in findcurrent)
                    {
                        Console.WriteLine(ord);
                    }
                    return "AdminOrderMenu";


                case "6":
                    Log.Information("User is selecting Show ALL Past Orders for a Store");
                    Console.WriteLine("Please Enter a Store ID");
                    int p_sPID = Convert.ToInt32(Console.ReadLine());
                    List<Orders> findold1 = _ordBL.SearchStoreOrders(p_sPID, "CANCELLED");
                    Console.WriteLine("CANCELLED Orders:");
                    foreach(Orders ord in findold1)
                    {
                        
                        Console.WriteLine(ord);
                    }
                    List<Orders> findold2 = _ordBL.SearchStoreOrders(p_sPID, "FULFILLED");
                    Console.WriteLine("FULFILLED Orders:");
                    foreach(Orders ord in findold2)
                    {
                        Console.WriteLine(ord);
                    }


                    return "AdminOrderMenu";


                default :
                    Console.WriteLine("Invalid Selection. Press Enter to Continue");
                    Console.ReadLine();
                    return "AdminOrderMenu";
            }







    
        }
    }


}