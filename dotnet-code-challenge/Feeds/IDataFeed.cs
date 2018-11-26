using System;
using System.Collections.Generic;
using System.IO;

namespace dotnet_code_challenge
{
    interface IDataFeed
    {
        event EventHandler<RaceDataEventArgs> RaceDataReceived;
        void Ingest(Stream stream);
    }

    public class RaceDataEventArgs : EventArgs
    {
        public RaceDataEventArgs(List<RaceData> raceData)
        {
            RaceData = raceData;
        }

        public List<RaceData> RaceData { get; set; }
    }
}
