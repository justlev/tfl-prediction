using System;
using System.Collections.Generic;
using TFLDataProvider.Models;

namespace AnnouncementsManager.Models
{
    // A better name than IAnnouncer would be in place, since it's repsonsible for scheduling and managing announcements.
    public interface IAnnouncer
    {
        void ScheduleAnnouncements(IEnumerable<ITflScheduledItem> items, Action<ITflScheduledItem> announceAction);
        void ClearSchedule();
    }
}