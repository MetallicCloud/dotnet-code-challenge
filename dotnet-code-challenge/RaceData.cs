
using System.Collections.Generic;

namespace dotnet_code_challenge
{
    public class Horse
    {
        public string Name { get; set; }
        public int Number { get; set; }
    };

    public class HorsePrice
    {
        public int HorseNumber { get; set; }
        public double Price { get; set; }
    };

    public class Price
    {
        public Price()
        {
            HorsePrices = new List<HorsePrice>();
        }

        public string PriceType { get; set; }
        public List<HorsePrice> HorsePrices { get; set; }
    };

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
    }
}
