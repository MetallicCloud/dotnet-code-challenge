using System;
using System.IO;
using System.Text;
using Xunit;

namespace dotnet_code_challenge.Test
{
    public class UnitTest1
    {
        [Fact]
        public void TestCaufieldDataFeed()
        {
            var testData =
                @"<?xml version=""1.0""?>
                  <races>
                    <race name=""TestName"">
                      <horses>
                        <horse name=""Horse1"">
                          <number>1</number>
                        </horse>
                        <horse name=""Horse2"">
                          <number>2</number>
                        </horse>
                      </horses>
                      <prices>
                        <price>
                          <priceType>WinFixedOdds</priceType>
                          <horses>
                            <horse number=""1"" Price=""5.2""/>
                            <horse number=""2"" Price=""3.4""/>
                          </horses>
                        </price>
                      </prices>
                    </race>
                  </races>";

            var caufieldDataFeed = new CaufieldDataFeed();
            caufieldDataFeed.RaceDataReceived += delegate (object sender, RaceDataEventArgs e)
            {
                RaceData expected = new RaceData { RaceName = "TestName" };
                expected.Horses.Add(1, new Horse { Name = "Horse1", Number = 1 });
                expected.Horses.Add(2, new Horse { Name = "Horse2", Number = 2 });

                Price price = new Price { PriceType = "WinFixedOdds" };
                price.HorsePrices.Add(new HorsePrice { Price = 5.2, HorseNumber = 1 });
                price.HorsePrices.Add(new HorsePrice { Price = 3.4, HorseNumber = 2 });
                expected.Prices.Add(price);

                Assert.Single(e.RaceData);
                Assert.Equal(expected, e.RaceData[0]);
            };

            using (MemoryStream fs = new MemoryStream(Encoding.UTF8.GetBytes(testData)))
            {
                caufieldDataFeed.Ingest(fs);
            }
        }

        // TODO: This would require many more tests to see how it deals with different edge cases

        [Fact]
        public void TestWolferhampton()
        {
            // TODO
        }
    }
}
