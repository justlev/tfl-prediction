using System;
using AnnouncementsManager.Models;
using StationState.Models;
using TFLDataProvider.Models;

namespace AnnouncementsManager.Services
{
    public class DefaultAnnouncementsManager : IAnnouncementsManager
    {
        private IAnnouncer _announcer;
        
        public event EventHandler<ITflScheduledItem> Announce;
        
        public DefaultAnnouncementsManager(IAnnouncer announcer)
        {
            _announcer = announcer;
        }
        
        public void ManageAnnouncementsByStationState(IStationState state)
        {
            state.ScheduleUpdated += OnScheduleUpdated;
        }

        private void OnScheduleUpdated(object sender, ITflStationSchedule e)
        {
            _announcer.ClearSchedule();
            _announcer.ScheduleAnnouncements(e.ScheduledItems, AnnounceItem);
        }

        private void AnnounceItem(ITflScheduledItem item)
        {
            Announce?.Invoke(this, item);
        }
    }
}