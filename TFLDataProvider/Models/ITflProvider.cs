using System;

namespace TFLDataProvider.Models
{
    public interface ITflProvider
    {
        void InitializeForStation(string stationId);
        void FetchDataImmediately();
        event EventHandler<ITflStationSchedule> DataReceived;
    }
}