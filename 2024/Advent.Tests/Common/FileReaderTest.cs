namespace Advent.Tests.Common;

public class FileReaderTest
{
    [Fact]
    public async Task ReadInputAsync_ShouldReturnFileContent()
    {
        // Arrange
        var fileReader = new FileReader();

        // Act
        var result = await fileReader.ReadInputAsync("day1");

        // Assert
        result.Should().StartWith("99006   28305");
    }

    [Fact]
    public async Task ReadInputAsync_ShouldThrowFileNotFoundException()
    {
        // Arrange
        var filePath = Path.GetRandomFileName();
        var fileReader = new FileReader();

        // Act & Assert
        await Assert.ThrowsAsync<FileNotFoundException>(() => fileReader.ReadInputAsync(filePath));
    }
}
