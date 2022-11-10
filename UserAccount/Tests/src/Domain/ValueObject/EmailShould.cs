using Xunit;

namespace Tests.src.Domain.ValueObject
{
    public class EmailShould
    {
        [Fact]
        public void Create_Valid_Email()
        {
            // Arrange
            string emailExpected = "ivancorlli@gmail.com";
            // Act
            Email newEmail = Email.Create("ivancorlli@gmail.com");
            // Assert
            
        }
    }
}