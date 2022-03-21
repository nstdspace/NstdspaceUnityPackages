using NUnit.Framework;

namespace Organization.Project.Tests
{
    public class UnitTest
    {
        [Test]
        public void TestNoopMethod()
        {
            Assert.DoesNotThrow(TestClass.DoNothing);
        }
    }
}