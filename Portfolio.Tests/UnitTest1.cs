using Portfolio.core;

namespace Portfolio.Tests
{
    [TestFixture]
    public class CoreReferenceTests
    {
        [Test]
        public void Can_Create_Core_Class_Instance()
        {
            // Act
            var instance = new Class1();

            // Assert
            Assert.NotNull(instance);
        }
    }
}