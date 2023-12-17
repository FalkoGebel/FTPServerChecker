using CheckerLibrary;

namespace CheckerLibraryHelpers
{
    public static class CheckerLibraryHelpers
    {
        private static readonly string saveFileName = "save.data";

        /// <summary>
        /// Creates a string for saving to a file for the given FTP Connection.
        /// </summary>
        public static string CreateFileString(this FtpConnection ftpConnection)
        {
            int ssl = 0;
            if (ftpConnection.UseSsl)
                ssl = 1;
            
            return $"{ftpConnection.ServerName}||{ftpConnection.UserId}||{ftpConnection.Password}||{ssl}";
        }

        /// <summary>
        /// Creates a FTP Connection from a file string for loading from a file.
        /// </summary>
        public static FtpConnection? CreateFtpConnectionFromFileString(this string fileString)
        {
            if (fileString == string.Empty)
                return null;

            string[] fields = fileString.Split("||");

            if (fields.Length != 4)
                return null;

            FtpConnection output = new()
            {
                ServerName = fields[0],
                UserId = fields[1],
                Password = fields[2],
                UseSsl = false
            };

            try
            {
                if (int.Parse(fields[3]) == 1)
                    output.UseSsl = true;
            }
            catch (FormatException)
            {
                return null;
            }

            return output;
        }

        /// <summary>
        /// Deletes the save file.
        /// </summary>
        public static void DeleteSaveFile()
        {
            File.Delete(saveFileName);
        }

        /// <summary>
        /// Loads from the save file and returns the text as string.
        /// </summary>
        /// <returns>String loaded from the save file.</returns>
        public static string LoadFromSaveFile()
        {
            return File.ReadAllText(saveFileName);
        }

        /// <summary>
        /// Creates the save file, if it does not exist and saves the given string to the file.
        /// </summary>
        /// <param name="fileString">String to save to the file.</param>
        public static void SaveToSaveFile(this string fileString)
        {
            File.WriteAllText(saveFileName, fileString);
        }
    }
}
