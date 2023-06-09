using Assignment_thinhvdph26886.Models;
using Newtonsoft.Json;
namespace Assignment_thinhvdph26886.Services
{
    public static class SessionServices
    {
        public static List<Product> GetObjFromSession(ISession session, string key)
        {
            //B1: lấy string data từ session ở dạng json
            string jsonData = session.GetString(key);
            if (jsonData == null) return new List<Product>();
            //B2: Convert về List
            var products = JsonConvert.DeserializeObject<List<Product>>(jsonData);
            return products;
        }
        //Ghi dữ liệu từ 1 list Session
        public static void SetObjToSession(ISession session, string key, object values)
        {
            var jsonData = JsonConvert.SerializeObject(values);
            session.SetString(key, jsonData);
        }
        public static bool CheckExistProduct(Guid id, List<Product> products)
        {
            return products.Any(x => x.ID == id);
        }
        public static bool isExistProduct(Guid id, List<Product> products)
        {
            return products.Any(p => p.ID == id);
        }
        //Kiểm tra sự tồn tại sửa sp trong list
    }
}
