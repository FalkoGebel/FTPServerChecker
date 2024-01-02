using System.Globalization;
using System.Net;

namespace CheckerLibrary
{
    public class FtpConnection
    {
        public string ServerName { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public bool UseSsl { get; set; }

        public FtpConnection()
        {
            ServerName = string.Empty;
            UserId = string.Empty;
            Password = string.Empty;
        }

        /// <summary>
        /// Checks if the connection fields are filled and throws exception, if not.
        /// </summary>
        /// <exception cref="MissingFieldException">Missing fields are explainded.</exception>
        private void CheckConnectionFieldsWithException()
        {
            List<string> missingFieldMessages = new();
            
            if (ServerName == "")
                missingFieldMessages.Add(Properties.Resources.NO_SERVER_NAME);

            if (UserId == "")
                missingFieldMessages.Add(Properties.Resources.NO_USER_ID);

            if (Password == "")
                missingFieldMessages.Add(Properties.Resources.NO_PASSWORD);

            if (missingFieldMessages.Count > 0)
                throw new MissingFieldException(string.Join("; ", missingFieldMessages));
        }

        /// <summary>
        /// Tests the FTP connection with the set parameters and "ListDirectory" as method.
        /// </summary>
        public string TestConnection()
        {
            try
            {
                CheckConnectionFieldsWithException();
            }
            catch (MissingFieldException ex)
            {
                return ex.Message;
            }

            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ServerName);
                request.Credentials = new NetworkCredential(UserId, Password);
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.EnableSsl = UseSsl;
                request.KeepAlive = false;

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                return $"{Properties.Resources.WELCOME_MSG}: {response.WelcomeMessage}\n{Properties.Resources.STATUS_CODE}: {response.StatusCode}\n{Properties.Resources.DESCRIPTION}: {response.StatusDescription}";
            }
            catch (UriFormatException)
            {
                return Properties.Resources.INVALID_URI;
            }
            catch (WebException ex)
            {
                string responseText = "";

                if (ex.Response != null)
                {
                    FtpWebResponse response = (FtpWebResponse)ex.Response;
                    responseText = $"\n{Properties.Resources.STATUS_CODE}: {response.StatusCode}\n{Properties.Resources.DESCRIPTION}: {response.StatusDescription}";
                }
                    
                return $"{Properties.Resources.MSG}: {ex.Message}" + responseText;
            }
            catch (Exception ex)
            {
                return $"{Properties.Resources.EXCEPTION}: {ex.Message}";
            }
        }
    }
}
