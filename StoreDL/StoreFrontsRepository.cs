using System.Text.Json;
using StoreModel;
namespace StoreDL
{
    /// <summary>
    /// StoreFront Repository CRUD
    /// </summary>
    public class StoreFrontsRepository : IStoreFrontsRepo
    {
        //Path to DB
        private string _filepath = "../StoreDL/";
        private string _jsonString;
        /// <summary>
        /// Write StoreFront to DB
        /// </summary>
        /// <param name="p_front"></param>
        /// <returns></returns>
        public StoreFronts AddStoreFronts(StoreFronts p_front)
        {
            string path = _filepath + "StoreFronts.json";
            List<StoreFronts> listofstorefronts = GetAllStoreFronts();
            listofstorefronts.Add(p_front);
            _jsonString = JsonSerializer.Serialize(listofstorefronts, new JsonSerializerOptions {WriteIndented = true});
            File.WriteAllText(path, _jsonString);
            return p_front;
        }
        /// <summary>
        /// Grab StoreFronts from DB
        /// </summary>
        /// <returns></returns>
        public List<StoreFronts> GetAllStoreFronts()
        {
            _jsonString = File.ReadAllText(_filepath + "StoreFronts.json");
            return JsonSerializer.Deserialize<List<StoreFronts>>(_jsonString);
        }

    }

}