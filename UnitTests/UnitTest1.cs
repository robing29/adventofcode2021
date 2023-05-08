namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsTrue(day7.getFuel(Math.Abs(16 - 5)) == day7.getFuel(11));
            Assert.IsTrue(day7.getFuel(11) == 66);
            Assert.IsTrue(day7.getFuel(3) == 6);
            Assert.IsTrue(day7.getFuel(5) == 15);
            Assert.IsTrue(day7.getFuel(1) == 1);
            Assert.IsTrue(day7.getFuel(2) == 3);
            Assert.IsTrue(day7.getFuel(4) == 10);
            Assert.IsTrue(day7.getFuel(9) == 45);
            Assert.IsTrue(day7.getFuel(0) == 0);
            Assert.IsTrue(day7.getFuel(100) == 5050);
            Assert.IsTrue(day7.getFuel(483) == 116886);

        }
    }
}