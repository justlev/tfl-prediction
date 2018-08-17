using System;

namespace TFLDataProvider.Models.Contracts
{
    [Serializable]
    public class TflScheduleItem : ITflScheduledItem
    {
        //Those fields are public, for serialisation purposes
        public string Id;
        public int OperationType;
        public string StationName;
        public string PlatformName;
        public DateTime ExpectedArrival;
        public string Towards;
        public int TimeToStation;
        
        
        // Users will receive the readonly version (interface), so we implement it here.
        string ITflScheduledItem.Id { get{ return Id; }}
        int ITflScheduledItem.OperationType { get{ return OperationType; }}
        string ITflScheduledItem.StationName { get{ return StationName; }}
        string ITflScheduledItem.PlatformName { get{ return PlatformName; }}
        DateTime ITflScheduledItem.ExpectedArrival { get{ return ExpectedArrival; }}
        string ITflScheduledItem.Towards { get{ return Towards; }}
        int ITflScheduledItem.TimeToStation { get{ return TimeToStation; }}
    }
}