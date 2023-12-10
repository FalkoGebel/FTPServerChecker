using CheckerLibrary;
using FluentAssertions;

namespace CheckerLibraryTestsMSTest
{
    [TestClass]
    public class ConfigFileTests
    {
        private ConfigFile? Sut = null;
        
        [TestMethod]
        public void Call_LoadConfigFile_with_missing_file_and_get_FileLoadException()
        {
            var loadingWithInvalidFileName = () => Sut = ConfigFile.LoadConfigFile("invalidFileName.txt");
            loadingWithInvalidFileName.Should().Throw<FileLoadException>()
                .Which.Message.Contains("config file not found", StringComparison.CurrentCultureIgnoreCase);
        }

        [TestMethod]
        public void Call_LoadConfigFile_with_existing_file_and_get_ConfigFile()
        {
            Sut = ConfigFile.LoadConfigFile();
            Sut.ServerName.Should().NotBeEmpty();
            Sut.UserId.Should().NotBeEmpty();
            Sut.Password.Should().NotBeEmpty();
        }
    }
}