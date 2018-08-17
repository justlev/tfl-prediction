using System;
using System.Linq;
using AnnouncementsManager.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StationBoard.Models;
using StationOrchestrator.Orchestrator;
using StationState.Models;
using TFLDataProvider.Models;

namespace StationOrchestrator.Tests.Orchestrator
{
    [TestClass]
    public class DefaultOrchestratorTests
    {
        private DefaultOrchestrator _subject;
        
        private Mock<ITflProvider> _provider;
        private Mock<IAnnouncementsManager> _announcementsManager;
        private Mock<IStationState> _stationState;
        private Mock<IStationBoard> _board;

        private Mock<ITflScheduledItem> _item;
        private Mock<ITflStationSchedule> _schedule;

        [TestInitialize]
        public void Setup()
        {
            _provider = new Mock<ITflProvider>();
            _announcementsManager = new Mock<IAnnouncementsManager>();
            _stationState = new Mock<IStationState>();
            _board = new Mock<IStationBoard>();
            _item = new Mock<ITflScheduledItem>();
            _schedule = new Mock<ITflStationSchedule>();
            
            _subject = new DefaultOrchestrator(_provider.Object, _stationState.Object, _announcementsManager.Object, _board.Object);
        }
        
        [TestMethod]
        public void When_AnnouncementsManager_TriggersAnnouncements_TheOrchestrator_TriggersBoard()
        {
            _announcementsManager.Raise(mock => mock.Announce += null, _item.Object);
            
            _board.Verify(board => board.Announce(_item.ToString()), Times.Once);
        }
        
        [TestMethod]
        public void When_TflDataIsUpdated_ItUpdatesTheStationState()
        {
            _provider.Raise(mock => mock.DataReceived += null, _schedule.Object);
            
            _stationState.Verify(state => state.UpdateState(_schedule.Object));
            
        }
        
        [TestMethod]
        public void When_TflDataIsUpdated_ItUpdatesTheScheduledItemsOnBoard()
        {
            var scheduledTrains = new string[] {"1", "2"};
            
            _schedule.Setup(schedule => schedule.ScheduledItems.Select(item => item.ToString()))
                .Returns(scheduledTrains);
            
            _provider.Raise(mock => mock.DataReceived += null, _schedule.Object);
            
            _board.Verify(board => board.ShowNextArrivals(scheduledTrains));

        }
    }
}