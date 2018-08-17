using System.Linq;
using AnnouncementsManager.Models;
using StationBoard.Models;
using StationOrchestrator.Models;
using StationState.Models;
using TFLDataProvider.Models;

namespace StationOrchestrator.Orchestrator
{
    public class DefaultOrchestrator : IStationOrchestrator
    {
        private ITflProvider _provider;
        private IAnnouncementsManager _announcementsManager;
        private IStationState _stationState;
        private IStationBoard _board;

        public DefaultOrchestrator(ITflProvider provider, IStationState state, IAnnouncementsManager announcementsManager, IStationBoard board)
        {
            _provider = provider;
            _stationState = state;
            _announcementsManager = announcementsManager;
            _board = board;
        }
        
        public void OrchestrateStation(string stationId)
        {
            _provider.InitializeForStation(stationId);
            _provider.DataReceived += OnTflDataUpdated;
            _announcementsManager.Announce += OnAnnounce;
        }

        private void OnAnnounce(object sender, ITflScheduledItem e)
        {
            _board.Announce(e.ToString());
        }

        private void OnTflDataUpdated(object sender, ITflStationSchedule e)
        {
            _stationState.UpdateState(e);
            _board.ShowNextArrivals(e.ScheduledItems.Select(item => item.ToString()));
        }
    }
}