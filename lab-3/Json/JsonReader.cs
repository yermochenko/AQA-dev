using lab_3.Logic;
using System;
using System.Text.Json;

namespace lab_3.Json
{
    public class JsonReader
    {
        public static MobilePhoneStoreChain Read(string json)
        {
            var result = JsonSerializer.Deserialize<MobilePhoneStoreChain>(json);
            foreach (var shop in result.Shops)
            {
                foreach (var phone in shop.Phones)
                {
                    if (phone.Shop.Id == shop.Id)
                    {
                        phone.Shop = shop;
                    }
                    else
                    {
                        throw new ArgumentException($"Phone {phone.Model} has ShopId #{phone.Shop.Id} which does not match parent Shop.Id #{shop.Id}");
                    }
                }
            }
            return result;
        }
    }
}
