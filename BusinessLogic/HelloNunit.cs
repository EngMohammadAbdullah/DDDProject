using NUnit.Framework;

namespace UnitTesting.GettingStarted.Tests
{
    [TestFixture]
    public class HelloNunit
    {
        [Test]
        public void TestHelloNunit()
        {
            Assert.AreNotEqual(true, false);
        }
    }
}