using StationOrchestrator.Models;
using TFLDataProvider.Models;

namespace StationOrchestrator.Orchestrator
{
    public class DefaultOrchestrator : IStationOrchestrator
    {
        private ITflProvider _provider;

        public DefaultOrchestrator(ITflProvider provider)
        {
            _provider = provider;
        }
        
        public void OrchestrateStation(string stationId)
        {
            _provider.InitializeForStation(stationId);
            _provider.DataReceived += OnTflDataUpdated;
        }

        private void OnTflDataUpdated(object sender, ITflStationSchedule e)
        {
            
        }
    }
}