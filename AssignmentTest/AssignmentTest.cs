using Assignment;
using Assignment.InterfaceCommand;

namespace AssignmentTest
{
    [TestClass]
    public class AssignmentTests
    {
        [TestMethod]
        public void VarsTest()
        {
            Robot robot1 = new();
            Assert.AreEqual(robot1.NumCommands, 6);
            var exp_com = 10;
            Robot robot2 = new(exp_com);
            Assert.AreEqual(robot2.NumCommands, exp_com);
            Assert.AreEqual(robot1.IsPowered, false);
            robot1.IsPowered = true;
            Assert.AreEqual(robot1.IsPowered, true);
            Assert.AreEqual(robot1.X, 0);
            robot1.X = -5;
            Assert.AreEqual(robot1.X, -5);
            Assert.AreEqual(robot1.Y, 0);
            robot1.Y = -5;
            Assert.AreEqual(robot1.Y, -5);
        }
        [TestMethod]
        public void TestCommands()
        {
            Robot testRobot = new Robot(1);
            Assert.AreEqual(testRobot.IsPowered, false);
            testRobot.LoadCommand(new OnCommand());
            testRobot.Run();
            Assert.AreEqual(testRobot.IsPowered, true);
        }

        [TestMethod]
        public void NullCommandTest()
        {
            Robot testRobot = new Robot();
            Assert.IsFalse(testRobot.Run());
        }

        [TestMethod]
        public void AllCommandsTest()
        {
            Robot testRobot = new Robot();
            testRobot.IsPowered = true;

            testRobot.LoadCommand(new NorthCommand());
            testRobot.Run();
            testRobot.LoadCommand(new EastCommand());
            testRobot.Run();
            testRobot.LoadCommand(new OnCommand());
            testRobot.Run();
            testRobot.LoadCommand(new SouthCommand());
            testRobot.Run();
            testRobot.LoadCommand(new OffCommand());
            testRobot.Run();
            testRobot.LoadCommand(new WestCommand());

            testRobot.Run();

            Assert.AreEqual(testRobot.X, 1);
            Assert.AreEqual(testRobot.Y, 0);
            Assert.IsFalse(testRobot.IsPowered);
        }

    }
}