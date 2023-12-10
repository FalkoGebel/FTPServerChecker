using CheckerLibrary;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckerLibraryTestsMSTest
{
    [TestClass]
    public class FtpConnectionTests
    {
        private FtpConnection Sut;

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
            var callingTestWithoutServer = () => Sut.TestConnection();
            callingTestWithoutServer.Should().Throw<MissingFieldException>()
                .Which.Message.Contains("server name", StringComparison.CurrentCultureIgnoreCase);
        }

        [TestMethod]
        public void FtpConnection_no_user_set_and_TestConnection_with_missing_user_error()
        {
            var callingTestWithoutUser = () => Sut.TestConnection();
            callingTestWithoutUser.Should().Throw<MissingFieldException>()
                .Which.Message.Contains("user id", StringComparison.CurrentCultureIgnoreCase);
        }

        [TestMethod]
        public void FtpConnection_no_password_set_and_TestConnection_with_missing_password_error()
        {
            var callingTestWithoutPassword = () => Sut.TestConnection();
            callingTestWithoutPassword.Should().Throw<MissingFieldException>()
                .Which.Message.Contains("password", StringComparison.CurrentCultureIgnoreCase);
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
        public void FtpConnection_all_fields_set_and_TestConnection_returning_status_information()
        {
            // get the credentials from a local file to keep the data private
            ConfigFile configFile = ConfigFile.LoadConfigFile();

            Sut.ServerName = configFile.ServerName;
            Sut.UserId = configFile.UserId;
            Sut.Password = configFile.Password;

            string statusInformation = Sut.TestConnection().ToLower();

            statusInformation.Should().Contain("status code");
            statusInformation.Should().Contain("description");
        }
    }
}
