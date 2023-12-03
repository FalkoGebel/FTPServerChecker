using CheckerLibrary;

namespace CheckerLibraryTests
{

    public class FtpConnectionTests
    {
        FtpConnection Sut;
        
        [SetUp]
        public void Setup()
        {
            Sut = new FtpConnection();
        }

        [Test]
        public void FtpConnection_is_not_null()
        {
            Assert.That(Sut, Is.Not.Null);
        }

        [Test]
        public void FtpConnection_no_server_set_and_server_empty()
        {
            Assert.That(Sut.ServerName, Is.EqualTo(""));
        }

        [Test]
        public void FtpConnection_server_set_and_server_name_correct()
        {
            string serverName = @"ftp:\\server.name.de";
            
            Sut.ServerName = serverName;
            
            Assert.That(Sut.ServerName, Is.EqualTo(serverName));
        }

        [Test]
        public void FtpConnection_no_user_set_and_user_empty()
        {
            Assert.That(Sut.UserId, Is.EqualTo(""));
        }

        [Test]
        public void FtpConnection_user_set_and_user_correct()
        {
            string userId = @"UserId";

            Sut.UserId = userId;

            Assert.That(Sut.UserId, Is.EqualTo(userId));
        }

        [Test]
        public void FtpConnection_no_password_set_and_password_empty()
        {
            Assert.That(Sut.Password, Is.EqualTo(""));
        }

        [Test]
        public void FtpConnection_password_set_and_password_correct()
        {
            string password = @"asldkjoe2904a";

            Sut.Password = password;

            Assert.That(Sut.Password, Is.EqualTo(password));
        }

        [Test]
        public void FtpConnection_no_ssl_flag_set_and_ssl_flag_false()
        {
            Assert.That(Sut.UseSsl, Is.EqualTo(false));
        }

        [Test]
        public void FtpConnection_ssl_flag_set_and_ssl_flag_true()
        {
            Sut.UseSsl = true;

            Assert.That(Sut.UseSsl, Is.EqualTo(true));
        }

        [Test]
        public void FtpConnection_ssl_flag_set_and_unset_and_ssl_flag_false()
        {
            Sut.UseSsl = true;
            Sut.UseSsl = false;

            Assert.That(Sut.UseSsl, Is.EqualTo(false));
        }

        [Test]
        public void FtpConnection_no_server_set_and_TestConnection_with_missing_server_error()
        {
            var ex = Assert.Throws<MissingFieldException>(() => Sut.TestConnection());
            StringAssert.Contains("server name", ex.Message.ToString().ToLower());
        }

        [Test]
        public void FtpConnection_no_user_set_and_TestConnection_with_missing_user_error()
        {
            var ex = Assert.Throws<MissingFieldException>(() => Sut.TestConnection());
            StringAssert.Contains("user id", ex.Message.ToString().ToLower());
        }

        [Test]
        public void FtpConnection_no_password_set_and_TestConnection_with_missing_password_error()
        {
            var ex = Assert.Throws<MissingFieldException>(() => Sut.TestConnection());
            StringAssert.Contains("password", ex.Message.ToString().ToLower());
        }

        [Test]
        public void FtpConnection_all_fields_set_with_invalid_server_name_and_TestConnection_returning_invalid_server_name()
        {
            Sut.ServerName = "server";
            Sut.UserId = "user";
            Sut.Password = "password";

            string statusInformation = Sut.TestConnection();

            StringAssert.Contains("server name is not a valid uri", statusInformation.ToLower());
        }

        [Test]
        public void FtpConnection_all_fields_set_and_TestConnection_returning_status_information()
        {
            // get the credentials from a local file to keep the data private
            ConfigFile configFile = ConfigFile.LoadConfigFile();

            Sut.ServerName = configFile.ServerName;
            Sut.UserId = configFile.UserId;
            Sut.Password = configFile.Password;

            string statusInformation = Sut.TestConnection();

            StringAssert.Contains("status code", statusInformation.ToLower());
            StringAssert.Contains("description", statusInformation.ToLower());
        }
    }
}