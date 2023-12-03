namespace CheckerLibrary
{
    public class ConfigFile
    {
        public string ServerName { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }

        public ConfigFile()
        {
            ServerName = string.Empty;
            UserId = string.Empty;
            Password = string.Empty;
        }

        /// <summary>
        /// Loads the config file properties from file in the temp directory on partition C.
        /// </summary>
        /// <param name="fileName">The file name of the config file - by default "config.data".</param>
        /// <returns></returns>
        /// <exception cref="FileLoadException">If file does not exist or cannot be read.</exception>
        public static ConfigFile LoadConfigFile(string fileName = @"config.data")
        {
            ConfigFile configFile = new();
            
            string filePath = @"C:Temp\" + fileName;

            if (!File.Exists(filePath))
                throw new FileLoadException($"Config file not found -> path: {filePath}");

            var lines = File.ReadLines(filePath);

            for (int i = 0; i < lines.Count(); i++)
            {
                if (i == 0)
                    configFile.ServerName = lines.ElementAt(i);
                else if (i == 1)
                    configFile.UserId = lines.ElementAt(i);
                else if (i == 2)
                    configFile.Password = lines.ElementAt(i);
                else
                    break;
            }

            return configFile;
        }
    }
}
