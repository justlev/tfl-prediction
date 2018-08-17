using AnnouncementsManager.Models;
using AnnouncementsManager.Services;
using ConsoleTestApp.Config;
using StationBoard;
using StationBoard.Models;
using StationOrchestrator.Models;
using StationOrchestrator.Orchestrator;
using StationState.Models;
using TFLDataProvider.Models;
using TFLDataProvider.Providers;

namespace ConsoleTestApp.Container
{
    public class DefaultContainer : IContainer
    {
        public IStationOrchestrator StationOrchestrator { get; private set; }
        public ITflProvider TflProvider { get;  private set; }
        public IStationState StationState { get; private set; }
        public IAnnouncementsManager AnnouncementsManager { get; private set; }
        public IStationBoard StationBoard { get; private set; }

        public DefaultContainer()
        {
            StationBoard = new FileStationBoard(DefaultAppConfig.ANNOUNCEMENTS_FILE, DefaultAppConfig.SCHEDULE_FILE, DefaultAppConfig.SCHEDULE_LENGTH);
            TflProvider = new PollingProvider();
            StationState = new DefaultStationState();
            AnnouncementsManager = new DefaultAnnouncementsManager(new DefaultAnnouncer());
            
            StationOrchestrator = new DefaultOrchestrator(TflProvider, StationState, AnnouncementsManager, StationBoard);
        }
        
        private static DefaultContainer _instance;
        public static DefaultContainer Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DefaultContainer();
                }

                return _instance;
            }
        }
    }
}