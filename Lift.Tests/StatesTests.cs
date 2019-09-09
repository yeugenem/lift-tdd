using Lift.Interfaces;
using NUnit.Framework;
using Moq;
using System;
using Lift.Implementation.States;

namespace Lift.Tests
{
    [TestFixture]
    public class StatesTests
    {
        [Test]
        public void Should_KeepDoorOpen_When_DoorWasOpen_And_NoTargetIsSet()
        {
            var sensors = new Mock<ISensorsSet>();
            sensors.Setup(x => x.DoorsOpen).Returns(true);

            AssertProgressToNewState<StateStandingDoorOpen>(new StateStandingDoorOpen(sensors.Object));
        }

        [Test]
        public void Should_StartClosingDoor_When_DoorWasOpen_And_NewTargetIsSet()
        {
            var sensors = new Mock<ISensorsSet>();
            sensors.Setup(x => x.DoorsOpen).Returns(true);
            sensors.Setup(x => x.FloorLocked).Returns(0);
            sensors.Setup(x => x.FloorRequestedExt).Returns(1);

            AssertProgressToNewState<StateStandingDoorClosing>(new StateStandingDoorOpen(sensors.Object));            
        }

        [Test]
        public void Should_KeepClosingDoor_When_DoorWasClosing_And_NotClosedYet()
        {
            var sensors = new Mock<ISensorsSet>();            
            sensors.Setup(x => x.DoorsClosed).Returns(false);            

            AssertProgressToNewState<StateStandingDoorClosing>(new StateStandingDoorClosing(sensors.Object));
        }

        [Test]
        public void Should_StopClosingDoor_When_DoorWasClosing_And_Closed()
        {
            var sensors = new Mock<ISensorsSet>();
            sensors.Setup(x => x.DoorsClosed).Returns(true);

            AssertProgressToNewState<StateStandingDoorClosed>(new StateStandingDoorClosing(sensors.Object));
        }

        [Test]
        public void Should_KeepClosedDoor_When_DoorWasClosed_And_TargetNotReached()
        {
            var sensors = new Mock<ISensorsSet>();
            sensors.Setup(x => x.DoorsClosed).Returns(true);
            sensors.Setup(x => x.FloorRequestedExt).Returns(3);
            sensors.Setup(x => x.FloorLocked).Returns(1);
            
            AssertProgressToNewState<StateStandingDoorClosed>(new StateStandingDoorClosed(sensors.Object));
        }

        [Test]
        public void Should_StartOpeningDoor_When_DoorWasClosed_And_TargetReached()
        {
            var sensors = new Mock<ISensorsSet>();
            sensors.Setup(x => x.DoorsClosed).Returns(true);
            sensors.Setup(x => x.FloorRequestedExt).Returns(3);
            sensors.Setup(x => x.FloorLocked).Returns(3);

            AssertProgressToNewState<StateStandingDoorOpening>(new StateStandingDoorClosed(sensors.Object));            
        }

        [Test]
        public void Should_KeepOpeningDoor_When_DoorWasOpening_And_NotOpenYet()
        {
            var sensors = new Mock<ISensorsSet>();
            sensors.SetupSequence(x => x.DoorsOpen).Returns(false);            

            AssertProgressToNewState<StateStandingDoorOpening>(new StateStandingDoorOpening(sensors.Object));            
        }

        [Test]
        public void Should_StopOpeningDoor_When_DoorWasOpening_And_Opened()
        {
            var sensors = new Mock<ISensorsSet>();
            sensors.SetupSequence(x => x.DoorsOpen).Returns(true);

            AssertProgressToNewState<StateStandingDoorOpen>(new StateStandingDoorOpening(sensors.Object));
        }


        private void AssertProgressToNewState<T>(IState curState)
        {            
            var newState = curState.Progress();
            Assert.That(newState, Is.InstanceOf<T>());
        }
    }
}
