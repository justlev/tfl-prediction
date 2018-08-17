using System;
using System.Collections.Generic;

namespace TFLDataProvider.Models.Contracts
{
    [Serializable]
    public class TflStationSchedule : ITflStationSchedule
    {
        public List<TflScheduleItem> Schedule = new List<TflScheduleItem>();
        
        IEnumerable<ITflScheduledItem> ITflStationSchedule.ScheduledItems
        {
            get { return Schedule; }
        }
    }
}