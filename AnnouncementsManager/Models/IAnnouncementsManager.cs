using System;
using StationState.Models;
using TFLDataProvider.Models;

namespace AnnouncementsManager.Models
{
    public interface IAnnouncementsManager
    {
        void ManageAnnouncementsByStationState(IStationState state);

        event EventHandler<ITflScheduledItem> Announce;
    }
}