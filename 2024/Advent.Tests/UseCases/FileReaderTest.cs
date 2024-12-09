using Advent.UseCases;

namespace Advent.Tests.UseCases;

public class FileReaderTest
{
    [Fact]
    public async Task ReadInputAsync_ShouldReturnFileContent()
    {
        // Arrange
        var filename = Path.GetRandomFileName();
        var filePath = Path.Combine(Path.GetTempPath(), filename);
        var expectedContent = "Hello, World!";
        await File.WriteAllTextAsync(filePath, expectedContent);
        var fileReader = new FileReader();

        // Act
        var result = await fileReader.ReadInputAsync(filePath);

        // Assert
        Assert.Equal(expectedContent, result);

        // Cleanup
        File.Delete(filePath);
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
