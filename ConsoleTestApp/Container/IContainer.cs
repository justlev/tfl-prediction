using AnnouncementsManager.Models;
using StationBoard.Models;
using StationOrchestrator.Models;
using StationState.Models;
using TFLDataProvider.Models;

namespace ConsoleTestApp.Container
{
    public interface IContainer
    {
        IStationOrchestrator StationOrchestrator { get; }
        ITflProvider TflProvider { get; }
        IStationState StationState { get; }
        IAnnouncementsManager AnnouncementsManager { get; }
        IStationBoard StationBoard { get; }
    }
}