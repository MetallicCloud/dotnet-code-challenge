using System;
using System.IO;
using System.Linq;

namespace dotnet_code_challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            var caufieldDataFeed = new CaufieldDataFeed();
            var wolferhamptonDataFeed = new WolferhamptonDataFeed();

            var dataFeedController = new DataFeedController();
            dataFeedController.RaceDataReceived += new EventHandler<RaceDataEventArgs>(PrintRaceData);
            dataFeedController.RegisterDataFeed(caufieldDataFeed);
            dataFeedController.RegisterDataFeed(wolferhamptonDataFeed);

            // Test code...it would come from a network or something normally I assume.

            try
            {
                using (FileStream fileStream = File.OpenRead("./FeedData/Caulfield_Race1.xml"))
                {
                    caufieldDataFeed.Ingest(fileStream);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to ingest data: " + e.ToString());
            }
        }

        private static void PrintRaceData(object sender, RaceDataEventArgs e)
        {
            foreach (RaceData raceData in e.RaceData)
            {
                Console.WriteLine(raceData);
                Console.WriteLine("");
            }
        }
    }
}
