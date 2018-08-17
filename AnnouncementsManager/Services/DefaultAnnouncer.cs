using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AnnouncementsManager.Models;
using TFLDataProvider.Models;

namespace AnnouncementsManager.Services
{
    public class DefaultAnnouncer : IAnnouncer
    {
        private Dictionary<string, CancellationTokenSource> _trainToCancellationToken= new Dictionary<string, CancellationTokenSource>();
        private object _lock = new object();
        
        public void ScheduleAnnouncements(IEnumerable<ITflScheduledItem> items, Action<ITflScheduledItem> announceAction)
        {
            foreach (var itemToAnnounce in items)
            {
                //For each item to announce - schedule an announcement task and create a cancellation token
                
                var task = new Task(() => AnnouncingTask(itemToAnnounce, announceAction));
                lock (_lock)
                {
                    _trainToCancellationToken[itemToAnnounce.Id] = new CancellationTokenSource();
                }
            }
        }

        public void ClearSchedule()
        {
            //When an update is received - we will clreat the scheduled - by cancelling all tokens.
            lock (_lock)
            {
                foreach (var pendingAnnouncement in _trainToCancellationToken)
                {
                    pendingAnnouncement.Value.Cancel();
                }       
            }
        }

        private void AnnouncingTask(ITflScheduledItem item, Action<ITflScheduledItem> announceAction)
        {
            Thread.Sleep(item.TimeToStation);
            lock (_lock)
            {
                if (_trainToCancellationToken.ContainsKey(item.Id))
                {
                    if (!_trainToCancellationToken[item.Id].IsCancellationRequested)
                    {
                        announceAction(item);
                        _trainToCancellationToken.Remove(item.Id);
                    }
                }
            }
        }
    }
}