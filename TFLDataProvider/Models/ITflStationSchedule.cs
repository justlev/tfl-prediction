using System.Collections.Generic;

namespace TFLDataProvider.Models
{
    public interface ITflStationSchedule
    {
        IEnumerable<ITflScheduledItem> ScheduledItems { get; }
    }
}