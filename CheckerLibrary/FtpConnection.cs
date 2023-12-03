﻿using System.Net;

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
                missingFieldMessages.Add("No server name is set");

            if (UserId == "")
                missingFieldMessages.Add("No user id is set");

            if (Password == "")
                missingFieldMessages.Add("No password is set");

            if (missingFieldMessages.Count > 0)
                throw new MissingFieldException(string.Join("; ", missingFieldMessages));
        }

        /// <summary>
        /// Tests the FTP connection with the set parameters.
        /// </summary>
        public string TestConnection()
        {
            CheckConnectionFieldsWithException();

            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ServerName);
                request.Credentials = new NetworkCredential(UserId, Password);
                request.EnableSsl = UseSsl;
                request.KeepAlive = false;

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                return $"Status code: {response.StatusCode}\nDescription: {response.StatusDescription}";
            }
            catch (UriFormatException)
            {
                return $"Server name is not a valid URI";
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    FtpWebResponse response = (FtpWebResponse)ex.Response;
                    return $"Status code: {response.StatusCode}\nDescription: {response.StatusDescription}";
                }
            }

            throw new NotSupportedException("Internal error: function \"TestConnection\" came to an end");
        }
    }
}
