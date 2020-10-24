using System;
using System.Threading.Tasks;
using Challenge.WebApi.Services;
using FakeItEasy;
using Xunit;

namespace Challenge.WebApi.Tests
{
    public class BackgrounQueueTests
    {
        [Fact]
        public void EnqueueNotNullItemShouldAddToQueue()
        {
            // Arrange
            var item = "test";
            var backgroundQueue = A.Fake<BackgroundQueue<string>>();
            
            // Act
            backgroundQueue.Enqueue(item);

            // Assert
            Assert.Equal(item, backgroundQueue.Dequeue());
        }

        [Fact]
        public void EnqueueNullItemShouldThrowException()
        {
            // Arrange
            var backgroundQueue = A.Fake<BackgroundQueue<string>>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => backgroundQueue.Enqueue(null));
        }
    }
}