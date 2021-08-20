using lab_3.Domain;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace lab_3.Logic
{
    class ShopComparer : IEqualityComparer<Shop>
    {
        public bool Equals([AllowNull] Shop x, [AllowNull] Shop y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode([DisallowNull] Shop shop)
        {
            return shop.Id.GetHashCode();
        }
    }
}
