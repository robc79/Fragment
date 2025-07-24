using Shouldly;

namespace Fragment.Domain.Tests;

public class TagTests
{
    public class Creation
    {
        [Theory]
        [InlineData("")]
        [InlineData("    ")]
        [InlineData(null)]
        public void NameMustBeSupplied(string? invalidName)
        {
            // Arrange

            // Act
            var action = () => { _ = new Tag(invalidName); };

            // Assert
            action.ShouldThrow<ArgumentException>();
        }
    }

    public class Name
    {
        [Theory]
        [InlineData("")]
        [InlineData("    ")]
        [InlineData(null)]
        public void MustBeSupplied(string? invalidName)
        {
            // Arrange
            var tag = new Tag("valid_name");

            // Act
            var action = () => { tag.Name = invalidName; };

            // Assert
            action.ShouldThrow<ArgumentException>();
        }
    }
}