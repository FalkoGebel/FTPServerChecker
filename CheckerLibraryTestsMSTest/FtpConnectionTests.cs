using CheckerLibrary;
using CheckerLibraryHelpers;
using FluentAssertions;

namespace CheckerLibraryTestsMSTest
{
    [TestClass]
    public class FtpConnectionTests
    {
        private FtpConnection? Sut;

        [TestInitialize]
        public void Initialize()
        {
            Sut = new FtpConnection();
        }
        
        [TestMethod]
        public void FtpConnection_is_not_null()
        {
            Sut.Should().NotBeNull();
        }

        [TestMethod]
        public void FtpConnection_no_server_set_and_server_empty()
        {
            Sut.ServerName.Should().BeEmpty();
        }

        [TestMethod]
        public void FtpConnection_server_set_and_server_name_correct()
        {
            string serverName = @"ftp:\\server.name.de";

            Sut.ServerName = serverName;

            Sut.ServerName.Should().Be(serverName);
        }

        [TestMethod]
        public void FtpConnection_no_user_set_and_user_empty()
        {
            Sut.UserId.Should().BeEmpty();
        }

        [TestMethod]
        public void FtpConnection_user_set_and_user_correct()
        {
            string userId = @"UserId";

            Sut.UserId = userId;

            Sut.UserId.Should().Be(userId);
        }

        [TestMethod]
        public void FtpConnection_no_password_set_and_password_empty()
        {
            Sut.Password.Should().BeEmpty();
        }

        [TestMethod]
        public void FtpConnection_password_set_and_password_correct()
        {
            string password = @"asldkjoe2904a";

            Sut.Password = password;

            Sut.Password.Should().Be(password);
        }

        [TestMethod]
        public void FtpConnection_no_ssl_flag_set_and_ssl_flag_false()
        {
            Sut.UseSsl.Should().BeFalse();
        }

        [TestMethod]
        public void FtpConnection_ssl_flag_set_and_ssl_flag_true()
        {
            Sut.UseSsl = true;

            Sut.UseSsl.Should().BeTrue();
        }

        [TestMethod]
        public void FtpConnection_ssl_flag_set_and_unset_and_ssl_flag_false()
        {
            Sut.UseSsl = true;
            Sut.UseSsl = false;

            Sut.UseSsl.Should().BeFalse();
        }

        [TestMethod]
        public void FtpConnection_no_server_set_and_TestConnection_with_missing_server_error()
        {
            Sut.TestConnection().ToLower().Should().Contain("no server name is set");
        }

        [TestMethod]
        public void FtpConnection_no_user_set_and_TestConnection_with_missing_user_error()
        {
            Sut.TestConnection().ToLower().Should().Contain("no user id is set");
        }

        [TestMethod]
        public void FtpConnection_no_password_set_and_TestConnection_with_missing_password_error()
        {
            Sut.TestConnection().ToLower().Should().Contain("no password is set");
        }

        [TestMethod]
        public void FtpConnection_all_fields_set_with_invalid_server_name_and_TestConnection_returning_invalid_server_name()
        {
            Sut.ServerName = "server";
            Sut.UserId = "user";
            Sut.Password = "password";

            Sut.TestConnection().ToLower().Should().Contain("server name is not a valid uri");
        }

        [TestMethod]
        public void Create_String_From_FtpConnection_and_String_is_correct_first_version()
        {
            Sut.ServerName = "server";
            Sut.UserId = "user";
            Sut.Password = "password";

            string expected = $"server||user||password||0";

            Sut.CreateFileString().Should().Be(expected);
        }

        [TestMethod]
        public void Create_String_From_FtpConnection_and_String_is_correct_second_version()
        {
            Sut.ServerName = "server";
            Sut.UserId = "user";
            Sut.Password = "password";
            Sut.UseSsl = true;

            string expected = $"server||user||password||1";

            Sut.CreateFileString().Should().Be(expected);
        }

        [TestMethod]
        public void Create_String_From_FtpConnection_and_String_is_correct_third_version()
        {
            Sut.ServerName = "ftp://ftp.bull.com";
            Sut.UserId = "PeterPaulMaria";
            Sut.Password = "abcd11223344";
            Sut.UseSsl = true;

            string expected = $"ftp://ftp.bull.com||PeterPaulMaria||abcd11223344||1";

            Sut.CreateFileString().Should().Be(expected);
        }

        [TestMethod]
        public void Create_FtpConnection_From_String_and_empty_String_returns_null()
        {
            string fileString = $"";

            fileString.CreateFtpConnectionFromFileString().Should().BeNull();
        }

        [TestMethod]
        public void Create_FtpConnection_From_String_and_invalid_String_returns_null()
        {
            string fileString = $"invalidString";

            fileString.CreateFtpConnectionFromFileString().Should().BeNull();
        }

        [TestMethod]
        public void Create_FtpConnection_From_String_and_valid_String_returns_not_null_and_correct_values()
        {
            string fileString = $"ftp://ftp.bull.com||PeterPaulMaria||abcd11223344||1";

            Sut = fileString.CreateFtpConnectionFromFileString();

            Sut.Should().NotBeNull();
            Sut.ServerName.Should().Be("ftp://ftp.bull.com");
            Sut.UserId.Should().Be("PeterPaulMaria");
            Sut.Password.Should().Be("abcd11223344");
            Sut.UseSsl.Should().BeTrue();
        }

        [TestMethod]
        public void Create_FtpConnection_From_String_and_only_three_fields_returns_null()
        {
            string fileString = $"PeterPaulMaria||abcd11223344||1";

            fileString.CreateFtpConnectionFromFileString().Should().BeNull();
        }

        [TestMethod]
        public void Create_File_From_File_String_and_file_exists()
        {
            string fileString = $"PeterPaulMaria||abcd11223344||1";
            string fileName = "save.data";

            fileString.SaveToSaveFile();

            File.Exists(fileName).Should().BeTrue();
        }

        [TestMethod]
        public void Get_File_String_From_File_and_string_is_correct()
        {
            string fileString = $"PeterPaulMaria||abcd11223344||1";

            fileString.SaveToSaveFile();

            CheckerLibraryHelpers.CheckerLibraryHelpers.LoadFromSaveFile().Should().Be(fileString);
        }

        [TestMethod]
        public void Delete_Save_File_and_file_does_not_exist()
        {
            string fileName = "save.data";

            CheckerLibraryHelpers.CheckerLibraryHelpers.DeleteSaveFile();

            File.Exists(fileName).Should().BeFalse();
        }
    }
}
