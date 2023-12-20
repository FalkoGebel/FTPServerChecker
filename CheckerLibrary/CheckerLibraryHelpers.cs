using CheckerLibrary;
using System.Security.Cryptography;
using System.Text;

namespace CheckerLibraryHelpers
{
    public static class CheckerLibraryHelpers
    {
        private static readonly string saveFileName = "save.data";
        private static readonly byte[] keyBytes = Encoding.UTF8.GetBytes("12345678901234567890123456789012");
        private static readonly byte[] ivBytes = Encoding.UTF8.GetBytes("1234567890123456");

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
            if (!File.Exists(saveFileName))
                return "";

            return DecryptText(File.ReadAllBytes(saveFileName));
        }

        /// <summary>
        /// Creates the save file, if it does not exist and saves the given string to the file.
        /// </summary>
        /// <param name="fileString">String to save to the file.</param>
        public static void SaveToSaveFile(this string fileString)
        {
            File.WriteAllBytes(saveFileName, EncryptText(fileString));
        }

        /// <summary>
        /// Encrypts the given string and returns the encrypted string.
        /// </summary>
        /// <returns>The encrypted string as bytes.</returns>
        private static byte[] EncryptText(string textToEnrypt)
        {
            byte[] encrypted;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = keyBytes;
                aesAlg.IV = ivBytes;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using MemoryStream msEncrypt = new();
                using CryptoStream csEncrypt = new(msEncrypt, encryptor, CryptoStreamMode.Write);
                using (StreamWriter swEncrypt = new(csEncrypt))
                    swEncrypt.Write(textToEnrypt);
                
                encrypted = msEncrypt.ToArray();
            }

            return encrypted;
        }

        /// <summary>
        /// Decrypts the as bytes given string and returns the original string.
        /// </summary>
        /// <returns>The original string.</returns>
        private static string DecryptText(byte[] encryptedText)
        {
            if (encryptedText == null || encryptedText.Length <= 0)
                return "";

            string originalText = "";

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = keyBytes;
                aesAlg.IV = ivBytes;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using MemoryStream msDecrypt = new(encryptedText);
                using CryptoStream csDecrypt = new(msDecrypt, decryptor, CryptoStreamMode.Read);
                using StreamReader srDecrypt = new(csDecrypt);
                originalText = srDecrypt.ReadToEnd();
            }

            return originalText;
        }
    }
}
