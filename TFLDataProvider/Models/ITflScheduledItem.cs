using System;

namespace TFLDataProvider.Models
{
    public interface ITflScheduledItem
    {
        string Id { get; }
        int OperationType { get; }
        string StationName { get; }
        string PlatformName { get; }
        DateTime ExpectedArrival { get; }
        string Towards { get; }
        int TimeToStation { get; }
    }
}