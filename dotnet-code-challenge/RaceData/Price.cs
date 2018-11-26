using System.Collections.Generic;
using System.Linq;

namespace dotnet_code_challenge
{
    public class Price
    {
        public Price()
        {
            HorsePrices = new List<HorsePrice>();
        }

        public string PriceType { get; set; }
        public List<HorsePrice> HorsePrices { get; set; }

        public override bool Equals(object obj)
        {
            var item = obj as Price;

            if (item == null)
            {
                return false;
            }

            return PriceType.Equals(item.PriceType) &&
                    HorsePrices.SequenceEqual(item.HorsePrices);
        }

        public override int GetHashCode()
        {
            return 23 * PriceType.GetHashCode() +
                    HorsePrices.GetHashCode();
        }

        public override string ToString()
        {
            return PriceType;
        }
    };
}
