using System;
using TFLDataProvider.Models;

namespace StationState.Models
{
    public interface IStationState
    {
        event EventHandler<ITflStationSchedule> ScheduleUpdated;
        
        ITflStationSchedule CurrentSchedule { get; }

        void UpdateState(ITflStationSchedule newSchedule);
    }
}