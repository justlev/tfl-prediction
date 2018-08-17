using System;
using TFLDataProvider.Models;

namespace TFLDataProvider.Providers
{
    public class PollingProvider : ITflProvider
    {
        public void InitializeForStation(string stationId)
        {
            
        }

        public void FetchDataImmediately()
        {
            
        }

        public event EventHandler<ITflStationSchedule> DataReceived;
    }
}