using System;
using System.Collections.Generic;
using AnnouncementsManager.Models;
using AnnouncementsManager.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StationState.Models;
using TFLDataProvider.Models;
using TFLDataProvider.Models.Contracts;

namespace AnnouncementsManager.Tests.Services
{
    [TestClass]
    public class DefaultAnnouncementsManagerTests
    {
        private IAnnouncementsManager _subject;
        private Mock<IAnnouncer> _mockAnnouncer;
        private Mock<IStationState> _state;
        
        [TestInitialize]
        public void Setup()
        {
            _mockAnnouncer = new Mock<IAnnouncer>();
            
            _state = new Mock<IStationState>();
            
            _subject = new DefaultAnnouncementsManager(_mockAnnouncer.Object);
            
            _subject.ManageAnnouncementsByStationState(_state.Object);
        }
        
        [TestMethod]
        public void When_ScheduleIsUpdated_AnnouncerIsTriggeredToReschedule()
        {
            //Raise event
            var newSchedule = new Mock<IEnumerable<ITflScheduledItem>>();
            _state.Raise(mock => mock.ScheduleUpdated += null, newSchedule);
            
            _mockAnnouncer.Verify(item => item.ClearSchedule(), Times.Once);
            _mockAnnouncer.Verify(item => item.ScheduleAnnouncements(newSchedule.Object, It.IsAny<Action<ITflScheduledItem>>()), Times.Once);
        }

        [TestMethod]
        public void When_RequestingManager_ToManageAnnouncements_ItRegistersTheAnnouncer_ForUpdates()
        {
            _subject.ManageAnnouncementsByStationState(_state.Object);
            
            _state.Verify(); //Figure out how to verify that registered to events using Moq (v. 4 - not supported, switch mocking framework?)
        }
    }
}