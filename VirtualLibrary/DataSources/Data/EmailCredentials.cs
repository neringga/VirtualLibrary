namespace VirtualLibrary.DataSources.Data
{
    public class EmailCredentials
    {
        private readonly string _password;
        private readonly int _smtpPort;
        private readonly string _smtpServer;
        private readonly string _username;

        public EmailCredentials()
        {
            var textFile = new TextFile();
            var credentials = textFile.ReadTextFile(StaticStrings.EmailCredentialsFile);
            foreach (var line in credentials)
            {
                var spLine = line.Split(' ');
                _username = spLine[0];
                _password = spLine[1];
                _smtpPort = int.Parse(spLine[3]);
                _smtpServer = spLine[2];
            }
        }

        public string GetUsername()
        {
            return _username;
        }

        public string GetPassword()
        {
            return _password;
        }

        public string GetServer()
        {
            return _smtpServer;
        }

        public int GetPort()
        {
            return _smtpPort;
        }
    }
}