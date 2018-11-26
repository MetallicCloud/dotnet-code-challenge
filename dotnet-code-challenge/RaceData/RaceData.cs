
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dotnet_code_challenge
{
    public class RaceData
    {
        public RaceData()
        {
            Horses = new Dictionary<int, Horse>();
            Prices = new List<Price>();
        }

        public string RaceName { get; set; }
        public Dictionary<int, Horse> Horses { get; set; } // use number as key for faster lookup
        public List<Price> Prices { get; set; }

        public List<Price> GetPrices()
        {
            return Prices;
        }

        public override bool Equals(object obj)
        {
            var item = obj as RaceData;

            if (item == null)
            {
                return false;
            }

            var different = Horses.Except(item.Horses).ToList();

            return RaceName.Equals(item.RaceName) &&
                    Horses.SequenceEqual(item.Horses) &&
                    Prices.SequenceEqual(item.Prices);
        }

        public override int GetHashCode()
        {
            return 23 * RaceName.GetHashCode() +
                    Horses.GetHashCode() +
                    Prices.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("Race: {0}\n", RaceName);
            result.Append("------------------\n");

            foreach (Price price in Prices)
            {
                result.AppendFormat("Type: {0}\n", price.PriceType);

                foreach (HorsePrice horsePrice in price.HorsePrices.OrderBy(horsePrice => horsePrice.Price))
                {
                    Horse horse;

                    if (Horses.TryGetValue(horsePrice.HorseNumber, out horse))
                    {
                        result.AppendFormat("\tPrice: {0}, Horse: {1}\n", horsePrice.Price, horse.Name);
                    }
                    else
                    {
                        result.Append("Error: \n");
                    }
                }
            }

            return result.ToString();
        }
    }
}
