
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace dotnet_code_challenge
{
    public class CaufieldDataFeed : IDataFeed
    {
        public event EventHandler<RaceDataEventArgs> RaceDataReceived;

        public CaufieldDataFeed()
        {
        }

        public void Ingest(Stream stream)
        {
            if (stream == null)
                return;

            var parsedRaceData = new List<RaceData>();
            var document = XDocument.Load(stream);
                
            foreach (XElement race in document.Descendants("race"))
            {
                RaceData raceData = new RaceData();

                var raceNameElement = race.Attribute("name");
                if (raceNameElement != null)
                    raceData.RaceName = raceNameElement.Value;

                XElement horsesElement = race.Element("horses");

                var horses = GetHorses(horsesElement);

                if (horses == null)
                    return;

                raceData.Horses = horses;

                foreach (XElement priceElement in race.Descendants("price"))
                {
                    Price price = GetPrice(priceElement);

                    if (price == null)
                        return;

                    raceData.Prices.Add(price);
                }

                parsedRaceData.Add(raceData);
            }
            
            
            RaceDataReceived(this, new RaceDataEventArgs(parsedRaceData));
        }

        private Dictionary<int, Horse> GetHorses(XElement horses)
        {
            if (horses == null)
                return null;

            var results = new Dictionary<int, Horse>();

            foreach (XElement horseElement in horses.Descendants("horse"))
            {
                var nameAttribute = horseElement.Attribute("name");

                if (nameAttribute == null)
                    continue;

                XElement horseNumberElement = horseElement.Element("number");
                if (horseNumberElement == null)
                    continue;

                int horseNumber;
                if (!Int32.TryParse(horseNumberElement.Value, out horseNumber))
                {
                    continue;
                }

                Horse horse = new Horse();
                horse.Name = nameAttribute.Value;
                horse.Number = horseNumber;
                results.Add(horseNumber, horse);
            }

            return results;
        }

        private Price GetPrice(XElement priceElement)
        {
            if (priceElement == null)
                return null;

            XElement priceTypeElement = priceElement.Element("priceType");
            if (priceTypeElement == null)
                return null;

            Price price = new Price();
            price.PriceType = priceTypeElement.Value;

            foreach (XElement horse in priceElement.Descendants("horse"))
            {
                var numberAttribute = horse.Attribute("number");

                int horseNumber;
                if (!Int32.TryParse(numberAttribute.Value, out horseNumber))
                {
                    continue;
                }

                var priceAttribute = horse.Attribute("Price");

                double priceValue;
                if (!Double.TryParse(priceAttribute.Value, out priceValue))
                {
                    continue;
                }

                HorsePrice horsePrice = new HorsePrice();
                horsePrice.HorseNumber = horseNumber;
                horsePrice.Price = priceValue;
                price.HorsePrices.Add(horsePrice);
            }

            return price;
        }
    }
}
