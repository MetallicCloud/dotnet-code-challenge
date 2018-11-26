
using System;
using System.IO;

namespace dotnet_code_challenge
{
    public class WolferhamptonDataFeed : IDataFeed
    {
        public event EventHandler<RaceDataEventArgs> RaceDataReceived;

        public WolferhamptonDataFeed()
        {
        }

        public void Ingest(Stream stream)
        {

        }
    }
}
