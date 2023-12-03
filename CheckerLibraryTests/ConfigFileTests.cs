using CheckerLibrary;

namespace CheckerLibraryTests
{
    public class ConfigFileTests
    {
        private ConfigFile? Sut = null;
        
        [Test]
        public void Call_LoadConfigFile_with_missing_file_and_get_FileLoadException()
        {
            var ex = Assert.Throws<FileLoadException>(() => Sut = ConfigFile.LoadConfigFile("invalidFileName.txt"));
            StringAssert.Contains("config file not found", ex.Message.ToString().ToLower());
        }

        [Test]
        public void Call_LoadConfigFile_with_existing_file_and_get_ConfigFile()
        {
            Sut = ConfigFile.LoadConfigFile();
            Assert.Multiple(() =>
            {
                Assert.That(Sut.ServerName, Is.Not.Empty);
                Assert.That(Sut.UserId, Is.Not.Empty);
                Assert.That(Sut.Password, Is.Not.Empty);
            });
        }
    }
}
