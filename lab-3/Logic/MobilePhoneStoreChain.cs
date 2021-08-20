using lab_3.Domain;
using System.Collections.Generic;

namespace lab_3.Logic
{
    public class MobilePhoneStoreChain
    {
        public List<Shop> Shops { get; set; }

        public Dictionary<Shop, Dictionary<OperationSystemType, List<MobilePhone>>> AvailableMobilePhones()
        {
            var result = new Dictionary<Shop, Dictionary<OperationSystemType, List<MobilePhone>>>(new ShopComparer());
            foreach (var shop in Shops)
            {
                var shopPhones = new Dictionary<OperationSystemType, List<MobilePhone>>();
                foreach (var mobilePhone in shop.Phones)
                {
                    if (mobilePhone.IsAvailable)
                    {
                        List<MobilePhone> phones = shopPhones.GetValueOrDefault(mobilePhone.OperationSystemType, null);
                        if (phones == null)
                        {
                            phones = new List<MobilePhone>();
                            shopPhones.Add(mobilePhone.OperationSystemType, phones);
                        }
                        phones.Add(mobilePhone);
                    }
                }
                result.Add(shop, shopPhones);
            }
            return result;
        }

        public List<MobilePhone> AvailableMobilePhones(string model, string shop = null)
        {
            var result = new List<MobilePhone>();
            var foundShop = shop == null;
            var found = false;
            var foundAvailable = false;
            foreach (var currentShop in Shops)
            {
                if (shop == null || currentShop.Name.Equals(shop))
                {
                    foreach (var mobilePhone in currentShop.Phones)
                    {
                        if (mobilePhone.Model.Equals(model))
                        {
                            found = true;
                            if (mobilePhone.IsAvailable)
                            {
                                foundAvailable = true;
                                foundShop = true;
                                result.Add(mobilePhone);
                            }
                        }
                    }
                }
            }
            if (foundShop)
            {
                if (found)
                {
                    if (foundAvailable)
                    {
                        return result;
                    }
                    else
                    {
                        throw new AvailableMobilePhonesNotFoundException();
                    }
                }
                else
                {
                    throw new MobilePhonesNotFoundException();
                }
            }
            else
            {
                throw new ShopNotFoundException();
            }
        }
    }
}
