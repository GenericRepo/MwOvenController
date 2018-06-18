using MicrowaveOvenController.Interfaces;
using MicrowaveOvenController.Utilities;
using Moq;
using NUnit.Framework;
using System;

namespace MicrowaveOvenController.UnitTests
{
    [TestFixture]
    public class MicrowaveOvenControllerTests
    {
        [TestCase(MicrowaveOvenState.OPENED)]
        public void DoorClosed_OpenDoor_StateTest(MicrowaveOvenState expectedResult)
        {
            Mock<IMicrowaveOvenHW> hwMock = new Mock<IMicrowaveOvenHW>();
            hwMock.Setup(hw => hw.DoorOpen).Returns(true);

            Utilities.MicrowaveOvenController controller = new Utilities.MicrowaveOvenController(hwMock.Object);

            hwMock.Raise(hw => hw.DoorOpenChanged += null, false);

            Assert.AreEqual(expectedResult, controller.MicrowaveState);
        }

        [TestCase(false)]
        public void DoorClosed_OpenDoor_HeaterTest(bool expectedResult)
        {
            Mock<IMicrowaveOvenHW> hwMock = new Mock<IMicrowaveOvenHW>();
            hwMock.Setup(hw => hw.DoorOpen).Returns(true);

            Utilities.MicrowaveOvenController controller = new Utilities.MicrowaveOvenController(hwMock.Object);

            hwMock.Raise(hw => hw.DoorOpenChanged += null, false);

            Assert.AreEqual(expectedResult, controller.HeaterOn);
        }

        [TestCase(true)]
        public void DoorClosed_OpenDoor_LightTest(bool expectedResult)
        {
            Mock<IMicrowaveOvenHW> hwMock = new Mock<IMicrowaveOvenHW>();
            hwMock.Setup(hw => hw.DoorOpen).Returns(true);

            Utilities.MicrowaveOvenController controller = new Utilities.MicrowaveOvenController(hwMock.Object);

            hwMock.Raise(hw => hw.DoorOpenChanged += null, false);

            Assert.AreEqual(expectedResult, controller.LightOn);
        }

        [TestCase(MicrowaveOvenState.CLOSED)]
        public void DoorOpened_CloseDoor_StateTest(MicrowaveOvenState expectedResult)
        {
            Mock<IMicrowaveOvenHW> hwMock = new Mock<IMicrowaveOvenHW>();
            hwMock.Setup(hw => hw.DoorOpen).Returns(false);

            Utilities.MicrowaveOvenController controller = new Utilities.MicrowaveOvenController(hwMock.Object, MicrowaveOvenState.OPENED);

            hwMock.Raise(hw => hw.DoorOpenChanged += null, false);

            Assert.AreEqual(expectedResult, controller.MicrowaveState);
        }

        [TestCase(false)]
        public void DoorOpened_CloseDoor_HeaterTest(bool expectedResult)
        {
            Mock<IMicrowaveOvenHW> hwMock = new Mock<IMicrowaveOvenHW>();
            hwMock.Setup(hw => hw.DoorOpen).Returns(false);

            Utilities.MicrowaveOvenController controller = new Utilities.MicrowaveOvenController(hwMock.Object, MicrowaveOvenState.OPENED);

            hwMock.Raise(hw => hw.DoorOpenChanged += null, false);

            Assert.AreEqual(expectedResult, controller.HeaterOn);
        }

        [TestCase(false)]
        public void DoorOpened_CloseDoor_LightTest(bool expectedResult)
        {
            Mock<IMicrowaveOvenHW> hwMock = new Mock<IMicrowaveOvenHW>();
            hwMock.Setup(hw => hw.DoorOpen).Returns(false);

            Utilities.MicrowaveOvenController controller = new Utilities.MicrowaveOvenController(hwMock.Object, MicrowaveOvenState.OPENED);

            hwMock.Raise(hw => hw.DoorOpenChanged += null, false);

            Assert.AreEqual(expectedResult, controller.LightOn);
        }

        [TestCase(MicrowaveOvenState.RUNNING)]
        public void DoorClosed_StartButtonPress_StateTest(MicrowaveOvenState expectedResult)
        {
            Mock<IMicrowaveOvenHW> hwMock = new Mock<IMicrowaveOvenHW>();

            Utilities.MicrowaveOvenController controller = new Utilities.MicrowaveOvenController(hwMock.Object, MicrowaveOvenState.CLOSED);

            hwMock.Raise(hw => hw.StartButtonPressed += null, EventArgs.Empty);
            hwMock.Verify(hw => hw.TurnOnHeater());

            Assert.AreEqual(expectedResult, controller.MicrowaveState);
        }

        [TestCase(true)]
        public void DoorClosed_StartButtonPress_HeaterTest(bool expectedResult)
        {
            Mock<IMicrowaveOvenHW> hwMock = new Mock<IMicrowaveOvenHW>();

            Utilities.MicrowaveOvenController controller = new Utilities.MicrowaveOvenController(hwMock.Object, MicrowaveOvenState.CLOSED);

            hwMock.Raise(hw => hw.StartButtonPressed += null, EventArgs.Empty);
            hwMock.Verify(hw => hw.TurnOnHeater());

            Assert.AreEqual(expectedResult, controller.HeaterOn);
        }

        [TestCase(false)]
        public void DoorClosed_StartButtonPress_LightTest(bool expectedResult)
        {
            Mock<IMicrowaveOvenHW> hwMock = new Mock<IMicrowaveOvenHW>();

            Utilities.MicrowaveOvenController controller = new Utilities.MicrowaveOvenController(hwMock.Object, MicrowaveOvenState.CLOSED);

            hwMock.Raise(hw => hw.StartButtonPressed += null, EventArgs.Empty);
            hwMock.Verify(hw => hw.TurnOnHeater());

            Assert.AreEqual(expectedResult, controller.LightOn);
        }

        [TestCase(MicrowaveOvenState.OPENED)]
        public void HeaterRunning_OpenDoor_StateTest(MicrowaveOvenState expectedResult)
        {
            Mock<IMicrowaveOvenHW> hwMock = new Mock<IMicrowaveOvenHW>();
            hwMock.Setup(hw => hw.DoorOpen).Returns(true);

            Utilities.MicrowaveOvenController controller = new Utilities.MicrowaveOvenController(hwMock.Object, MicrowaveOvenState.RUNNING);

            hwMock.Raise(hw => hw.DoorOpenChanged += null, true);
            hwMock.Verify(hw => hw.TurnOffHeater());

            Assert.AreEqual(expectedResult, controller.MicrowaveState);
        }

        [TestCase(false)]
        public void HeaterRunning_OpenDoor_HeaterTest(bool expectedResult)
        {
            Mock<IMicrowaveOvenHW> hwMock = new Mock<IMicrowaveOvenHW>();
            hwMock.Setup(hw => hw.DoorOpen).Returns(true);

            Utilities.MicrowaveOvenController controller = new Utilities.MicrowaveOvenController(hwMock.Object, MicrowaveOvenState.RUNNING);

            hwMock.Raise(hw => hw.DoorOpenChanged += null, true);
            hwMock.Verify(hw => hw.TurnOffHeater());

            Assert.AreEqual(expectedResult, controller.HeaterOn);
        }

        [TestCase(true)]
        public void HeaterRunning_OpenDoor_LightTest(bool expectedResult)
        {
            Mock<IMicrowaveOvenHW> hwMock = new Mock<IMicrowaveOvenHW>();
            hwMock.Setup(hw => hw.DoorOpen).Returns(true);

            Utilities.MicrowaveOvenController controller = new Utilities.MicrowaveOvenController(hwMock.Object, MicrowaveOvenState.RUNNING);

            hwMock.Raise(hw => hw.DoorOpenChanged += null, true);
            hwMock.Verify(hw => hw.TurnOffHeater());

            Assert.AreEqual(expectedResult, controller.LightOn);
        }

        [TestCase(MicrowaveOvenState.OPENED)]
        public void DoorOpened_StartButtonPress_StateTest(MicrowaveOvenState expectedResult)
        {
            Mock<IMicrowaveOvenHW> hwMock = new Mock<IMicrowaveOvenHW>();

            Utilities.MicrowaveOvenController controller = new Utilities.MicrowaveOvenController(hwMock.Object, MicrowaveOvenState.OPENED);

            hwMock.Setup(hw => hw.DoorOpen).Returns(true);
            hwMock.Raise(hw => hw.StartButtonPressed += null, EventArgs.Empty);

            Assert.AreEqual(expectedResult, controller.MicrowaveState);
        }

        [TestCase(false)]
        public void DoorOpened_StartButtonPress_HeaterTest(bool expectedResult)
        {
            Mock<IMicrowaveOvenHW> hwMock = new Mock<IMicrowaveOvenHW>();

            Utilities.MicrowaveOvenController controller = new Utilities.MicrowaveOvenController(hwMock.Object, MicrowaveOvenState.OPENED);

            hwMock.Setup(hw => hw.DoorOpen).Returns(true);
            hwMock.Raise(hw => hw.StartButtonPressed += null, EventArgs.Empty);

            Assert.AreEqual(expectedResult, controller.HeaterOn);
        }

        [TestCase(true)]
        public void DoorOpened_StartButtonPress_LightTest(bool expectedResult)
        {
            Mock<IMicrowaveOvenHW> hwMock = new Mock<IMicrowaveOvenHW>();

            Utilities.MicrowaveOvenController controller = new Utilities.MicrowaveOvenController(hwMock.Object, MicrowaveOvenState.OPENED);

            hwMock.Setup(hw => hw.DoorOpen).Returns(true);
            hwMock.Raise(hw => hw.StartButtonPressed += null, EventArgs.Empty);

            Assert.AreEqual(expectedResult, controller.LightOn);
        }

        [TestCase(MicrowaveOvenState.RUNNING)]
        public void HeaterRunning_StartButtonPress_StateTest(MicrowaveOvenState expectedResult)
        {
            Mock<IMicrowaveOvenHW> hwMock = new Mock<IMicrowaveOvenHW>();

            Utilities.MicrowaveOvenController controller = new Utilities.MicrowaveOvenController(hwMock.Object, MicrowaveOvenState.RUNNING);

            hwMock.Raise(hw => hw.StartButtonPressed += null, EventArgs.Empty);

            Assert.AreEqual(expectedResult, controller.MicrowaveState);
        }

        [TestCase(true)]
        public void HeaterRunning_StartButtonPress_HeaterTest(bool expectedResult)
        {
            Mock<IMicrowaveOvenHW> hwMock = new Mock<IMicrowaveOvenHW>();

            Utilities.MicrowaveOvenController controller = new Utilities.MicrowaveOvenController(hwMock.Object, MicrowaveOvenState.RUNNING);

            hwMock.Raise(hw => hw.StartButtonPressed += null, EventArgs.Empty);

            Assert.AreEqual(expectedResult, controller.HeaterOn);
        }

        [TestCase(false)]
        public void HeaterRunning_StartButtonPress_LightTest(bool expectedResult)
        {
            Mock<IMicrowaveOvenHW> hwMock = new Mock<IMicrowaveOvenHW>();

            Utilities.MicrowaveOvenController controller = new Utilities.MicrowaveOvenController(hwMock.Object, MicrowaveOvenState.RUNNING);

            hwMock.Raise(hw => hw.StartButtonPressed += null, EventArgs.Empty);

            Assert.AreEqual(expectedResult, controller.LightOn);
        }

        [TestCase(MicrowaveOvenState.CLOSED)]
        public void HeaterRunning_TimerFinish_StateTest(MicrowaveOvenState expectedResult)
        {
            Mock<IMicrowaveOvenHW> hwMock = new Mock<IMicrowaveOvenHW>();

            Utilities.MicrowaveOvenController controller = new Utilities.MicrowaveOvenController(hwMock.Object, MicrowaveOvenState.RUNNING);

            ITimer timer = controller.Timer;
            timer.InvokeFinished();

            hwMock.Verify(hw => hw.TurnOffHeater());

            Assert.AreEqual(expectedResult, controller.MicrowaveState);
        }

        [TestCase(false)]
        public void HeaterRunning_TimerFinish_HeaterTest(bool expectedResult)
        {
            Mock<IMicrowaveOvenHW> hwMock = new Mock<IMicrowaveOvenHW>();

            Utilities.MicrowaveOvenController controller = new Utilities.MicrowaveOvenController(hwMock.Object, MicrowaveOvenState.RUNNING);

            ITimer timer = controller.Timer;
            timer.InvokeFinished();

            hwMock.Verify(hw => hw.TurnOffHeater());

            Assert.AreEqual(expectedResult, controller.HeaterOn);
        }

        [TestCase(false)]
        public void HeaterRunning_TimerFinish_LightTest(bool expectedResult)
        {
            Mock<IMicrowaveOvenHW> hwMock = new Mock<IMicrowaveOvenHW>();

            Utilities.MicrowaveOvenController controller = new Utilities.MicrowaveOvenController(hwMock.Object, MicrowaveOvenState.RUNNING);

            ITimer timer = controller.Timer;
            timer.InvokeFinished();

            hwMock.Verify(hw => hw.TurnOffHeater());

            Assert.AreEqual(expectedResult, controller.LightOn);
        }
    }
}

