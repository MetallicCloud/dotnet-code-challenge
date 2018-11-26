

using System;
using System.IO;

namespace dotnet_code_challenge
{
    class CaufieldDataFeed : IDataFeed
    {
        public event EventHandler<RaceDataEventArgs> RaceDataReceived;

        public CaufieldDataFeed()
        {
        }

        public void Ingest(FileInfo fileInfo)
        {

        }
    }
}
