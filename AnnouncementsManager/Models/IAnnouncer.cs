using System;
using System.Collections.Generic;
using TFLDataProvider.Models;

namespace AnnouncementsManager.Models
{
    public interface IAnnouncer
    {
        void ScheduleAnnouncements(IEnumerable<ITflScheduledItem> items, Action<ITflScheduledItem> announceAction);
        void ClearSchedule();
    }
}