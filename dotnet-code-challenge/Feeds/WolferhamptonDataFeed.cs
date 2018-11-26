
using System;
using System.IO;

namespace dotnet_code_challenge
{
    class WolferhamptonDataFeed : IDataFeed
    {
        public event EventHandler<RaceDataEventArgs> RaceDataReceived;

        public WolferhamptonDataFeed()
        {
        }

        public void Ingest(FileInfo fileInfo)
        {

        }
    }
}
