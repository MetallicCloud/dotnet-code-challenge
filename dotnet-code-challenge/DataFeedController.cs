
using System;
using System.Collections.Generic;

namespace dotnet_code_challenge
{
    class DataFeedController
    {
        public event EventHandler<RaceDataEventArgs> RaceDataReceived;

        private List<IDataFeed> m_dataFeeds = new List<IDataFeed>();

        public void RegisterDataFeed(IDataFeed dataFeed)
        {
            if (dataFeed == null)
                return;

            dataFeed.RaceDataReceived += new EventHandler<RaceDataEventArgs>(HandleRaceData);
            m_dataFeeds.Add(dataFeed);
        }

        private void HandleRaceData(object sender, RaceDataEventArgs args)
        {
            RaceDataReceived(sender, args);
        }

    }
}
