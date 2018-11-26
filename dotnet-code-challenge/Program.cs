using System;

namespace dotnet_code_challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataFeedController = new DataFeedController();
            dataFeedController.RaceDataReceived += new EventHandler<RaceDataEventArgs>(PrintRaceData);
            dataFeedController.RegisterDataFeed(new CaufieldDataFeed());
            dataFeedController.RegisterDataFeed(new WolferhamptonDataFeed());
        }

        private static void PrintRaceData(object sender, RaceDataEventArgs e)
        {
            Console.WriteLine("GOT RACE DATA!");
        }
    }
}
