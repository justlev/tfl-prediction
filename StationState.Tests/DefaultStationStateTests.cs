using Microsoft.VisualStudio.TestTools.UnitTesting;
using StationState.Models;
using TFLDataProvider.Models;
using TFLDataProvider.Models.Contracts;

namespace StationState.Tests
{
    [TestClass]
    public class DefaultStationStateTests
    {
        private IStationState _subject;

        [TestInitialize]
        public void Setup()
        {
            _subject = new DefaultStationState();
        }
        
        [TestMethod]
        public void When_UpdatingSchedule_AnEventFiresCorrectly()
        {
            ITflStationSchedule eventState = null;
            _subject.ScheduleUpdated += delegate(object sender, ITflStationSchedule schedule) { eventState = schedule; };
            ITflStationSchedule newState = new TflStationSchedule(); //better to use mocks
            
            _subject.UpdateState(newState);
            
            Assert.AreEqual(newState, eventState);
        }
        
        [TestMethod]
        public void When_UpdatingSchedule_CurrentStateIsUpdatedToNewState()
        {
            ITflStationSchedule newState = new TflStationSchedule(); //better to use mocks
            
            _subject.UpdateState(newState);
            
            Assert.AreEqual(newState, _subject.CurrentSchedule);
        }
    }
}