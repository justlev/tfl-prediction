using System;
using TFLDataProvider.Models;

namespace StationState.Models
{
    public class DefaultStationState : IStationState
    {
        public event EventHandler<ITflStationSchedule> ScheduleUpdated;
        
        public ITflStationSchedule CurrentSchedule { get; private set; }
        
        public void UpdateState(ITflStationSchedule newSchedule)
        {
            CurrentSchedule = newSchedule;
            ScheduleUpdated?.Invoke(this, newSchedule);
        }
    }
}